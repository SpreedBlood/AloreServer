namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.Room.Packets.Outgoing;

    internal class GetFurnitureAliasesEvent : IAsyncPacket
    {
        public short Header => 2443;

        public async Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            await session.WriteAndFlushAsync(new FurnitureAliasesComposer());
        }
    }
}
