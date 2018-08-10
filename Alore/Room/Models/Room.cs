namespace Alore.Room.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Threading.Tasks.Dataflow;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Room.Entities;
    using Alore.API.Room.Grid;
    using Alore.API.Room.Rights;
    using Alore.API.Tasks;
    using Alore.Room.Models.Entities;
    using API.Room.Models;

    internal class Room : IRoom, IDisposable
    {
        private readonly EntityHandler _entityHandler;
        private readonly CancellationTokenSource _cancellationToken;
        private ActionBlock<DateTimeOffset> task;

        internal Room(IRoomData roomData, IRoomModel model)
        {
            RoomData = roomData;
            RoomModel = model;

            _cancellationToken = new CancellationTokenSource();
            RoomGrid = new RoomGrid(RoomModel);
            _entityHandler = new EntityHandler(this);
        }

        public RoomGrid RoomGrid { get; }
        public IRoomData RoomData { get; set; }
        public IRoomModel RoomModel { get; set; }
        public IDictionary<int, BaseEntity> Entities => _entityHandler.Entities;
        public bool CycleActive => _cancellationToken.IsCancellationRequested;

        public void LeaveRoom(ISession session)
        {
            int entityId = session.Entity.Id;
            _entityHandler.RemoveEntity(entityId);
            session.Entity = null;

            if (!_entityHandler.HasUserEntities)
            {
                StopRoomCycle();
            }
        }

        public void SetupRoomCycle()
        {
            task = TaskHandler.PeriodicTaskWithDelay(time => Cycle(time), _cancellationToken.Token, 500);
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
            _entityHandler.Cycle(timeOffset);
        }

        public RoomRight GetRoomRight(uint entityId)
        {
            if (entityId == RoomData.OwnerId)
            {
                return RoomRight.OWNER;
            }

            return RoomRight.REGULAR;
        }

        public Task SendAsync(ServerPacket serverPacket) => _entityHandler.SendAsync(serverPacket);

        public void AddEntity(BaseEntity entity) => _entityHandler.AddEntity(entity);

        public void Dispose()
        {
            StopRoomCycle();
            _entityHandler.Dispose();
        }
    }
}