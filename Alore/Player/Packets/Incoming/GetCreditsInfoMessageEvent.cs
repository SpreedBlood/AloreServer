namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    public static class GetCreditsInfoMessageEvent
    {
        public static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            await session.WriteAndFlushAsync(new CreditBalanceComposer(session.Player.Credits));
            await session.WriteAndFlushAsync(
                new ActivityPointsComposer(session.Player.Duckets, session.Player.Diamonds));
        }
    }
}
