namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Room;
    using Alore.API.Room.Models;
    using Alore.Room.Packets.Outgoing;

    internal class OpenFlatConnectionEvent : IAsyncPacket
    {
        private readonly IRoomController _roomController;

        public OpenFlatConnectionEvent(IRoomController roomController)
        {
            _roomController = roomController;
        }

        public short Header => 3464;

        public async Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            int roomId = clientPacket.ReadInt();
            string password = clientPacket.ReadString();

            IRoom room = await _roomController.GetRoomByIdAndPassword(roomId, password);
            if (room != null)
            {
                await session.WriteAndFlushAsync(new OpenConnectionComposer());
                await session.WriteAndFlushAsync(new RoomReadyComposer(room.RoomData.ModelName, room.RoomData.Id));
                session.CurrentRoom = room;
            }
            else
            {
                await session.WriteAndFlushAsync(new CloseConnectionComposer());
            }
        }
    }
}
