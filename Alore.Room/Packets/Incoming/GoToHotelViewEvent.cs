namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using Alore.API.Room.Models;

    internal class GoToHotelViewEvent : AbstractAsyncPacket
    {
        public override short Header => 3119;

        protected override Task HandleAsync(ISession session)
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