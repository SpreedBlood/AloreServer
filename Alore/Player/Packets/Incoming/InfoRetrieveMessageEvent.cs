namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    public static class InfoRetrieveMessageEvent
    {
        public static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            await session.WriteAndFlushAsync(new UserObjectComposer(session.Player));
            await session.WriteAndFlushAsync(new UserPerksComposer());
        }
    }
}
