namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;

    internal class RequestFurniInventoryEvent : IAsyncPacket
    {
        public short Header => 2835;

        public Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            throw new System.NotImplementedException();
        }
    }
}
