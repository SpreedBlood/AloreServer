namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using Alore.API.Room;
    using Alore.API.Room.Entities;
    using Alore.API.Room.Models;
    using Alore.API.Room.Rights;
    using Outgoing;

    internal class GetRoomEntryDataEvent : AbstractAsyncPacket
    {
        private readonly IRoomController _roomController;

        public GetRoomEntryDataEvent(IRoomController roomController)
        {
            _roomController = roomController;
        }

        public override short Header => 1583;

        protected override async Task HandleAsync(ISession session)
        {
            IRoom room = session.CurrentRoom;

            await session.WriteAndFlushAsync(new HeightMapComposer(room.RoomModel));
            await session.WriteAndFlushAsync(new FloorHeightMapComposer(-1, room.RoomModel.RelativeHeightMap));

            BaseEntity userEntity = _roomController.AddUserToRoom(room, session);

            await session.WriteAndFlushAsync(new RoomEntryInfoComposer(room.RoomData.Id,
                room.GetRoomRight(session.Player.Id) == RoomRight.OWNER));
            await session.WriteAndFlushAsync(new EntitiesComposer(room.Entities.Values));
            await session.WriteAndFlushAsync(new EntityUpdateComposer(room.Entities.Values));

            await session.WriteAndFlushAsync(new RoomVisualizationSettingsComposer(false, 0, 0));
        }
    }
}