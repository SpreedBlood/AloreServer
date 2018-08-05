namespace Alore.Room.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using Alore.API.Network.Packets;
    using Alore.API.Room.Entities;
    using Alore.API.Room.Rights;
    using Alore.API.Tasks;
    using Alore.Room.Models.Entities;
    using API.Room.Models;

    internal class Room : IRoom, IDisposable
    {
        private readonly CancellationTokenSource _cancellationToken;
        private ActionBlock<DateTimeOffset> task;

        public IRoomData RoomData { get; set; }
        public IRoomModel RoomModel { get; set; }

        public IDictionary<int, BaseEntity> Entities { get; private set; }
        public bool CycleActive => _cancellationToken.IsCancellationRequested;

        internal Room(IRoomData roomData, IRoomModel model)
        {
            RoomData = roomData;
            RoomModel = model;

            Entities = new Dictionary<int, BaseEntity>();
            _cancellationToken = new CancellationTokenSource();
        }

        public void SetupRoomCycle(TaskHandler taskHandler)
        {
            task = taskHandler.PeriodicTaskWithDelay(time => Cycle(time), _cancellationToken.Token, 500);
            task.Post(DateTimeOffset.Now);
        }

        public void StopRoomCycle()
        {
            using (_cancellationToken)
            {
                _cancellationToken.Cancel();
            }

            task = null;
        }

        private void Cycle(DateTimeOffset timeOffset)
        {
            Console.WriteLine(timeOffset.Second);
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
            StopRoomCycle();
            Entities.Clear();
            Entities = null;
        }
    }
}