namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal class GetCreditsInfoMessageEvent : AbstractAsyncPacket
    {
        public override short Header { get; } = 2109;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new CreditBalanceComposer(session.Player.Credits));
            await session.WriteAndFlushAsync(
                new ActivityPointsComposer(session.Player.Duckets, session.Player.Diamonds));
        }
    }
}