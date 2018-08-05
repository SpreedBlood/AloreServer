namespace Alore.Room.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Alore.API.Network.Packets;
    using Alore.API.Room.Entities;
    using Alore.API.Room.Rights;
    using Alore.Room.Models.Entities;
    using API.Room.Models;

    internal class Room : IRoom, IDisposable
    {
        public IRoomData RoomData { get; set; }
        public IRoomModel RoomModel { get; set; }

        public IDictionary<int, BaseEntity> Entities { get; private set; }

        internal Room(IRoomData roomData, IRoomModel model)
        {
            RoomData = roomData;
            RoomModel = model;

            Entities = new Dictionary<int, BaseEntity>();
        }

        public RoomRight GetRoomRight(uint entityId)
        {
            if (entityId == RoomData.OwnerId)
            {
                return RoomRight.OWNER;
            }

            return RoomRight.REGULAR;
        }

        public async Task SendAsync(ServerPacket serverPacket)
        {
            foreach (BaseEntity entity in Entities.Values)
            {
                if (entity is UserEntity userEntity)
                {
                    await userEntity.Session.WriteAndFlushAsync(serverPacket);
                }
            }
        }

        public void AddEntity(BaseEntity entity) => Entities.Add(entity.Id, entity);

        public void Dispose()
        {
            Entities.Clear();
            Entities = null;
        }
    }
}