namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;

    internal class GetFurnitureAliasesEvent : IAsyncPacket
    {
        public short Header => 2443;

        public async Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
        }
    }
}
