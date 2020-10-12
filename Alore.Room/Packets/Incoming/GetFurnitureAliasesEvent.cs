namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal class GetFurnitureAliasesEvent : AbstractAsyncPacket
    {
        public override short Header => 2443;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new FurnitureAliasesComposer());
        }
    }
}