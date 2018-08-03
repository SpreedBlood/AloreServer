namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Room;
    using Alore.API.Room.Models;
    using Alore.Room.Packets.Outgoing;

    internal class GetRoomEntryDataEvent : IAsyncPacket
    {
        private readonly IRoomController _roomController;

        public GetRoomEntryDataEvent(IRoomController roomController)
        {
            _roomController = roomController;
        }

        public short Header => 1583;

        public async Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            IRoom room = session.CurrentRoom;

            await session.WriteAndFlushAsync(new HeightMapComposer(room.RoomModel));
        }
    }
}
