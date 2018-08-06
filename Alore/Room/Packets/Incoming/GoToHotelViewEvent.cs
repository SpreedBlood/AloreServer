namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Room.Models;

    internal class GoToHotelViewEvent : IAsyncPacket
    {
        public short Header => 3119;

        public Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            IRoom room = session.CurrentRoom;
            if (room != null)
            {
                room.LeaveRoom(session);
            }

            //TODO: Send packets to close the connection.
            return Task.CompletedTask;
        }
    }
}
