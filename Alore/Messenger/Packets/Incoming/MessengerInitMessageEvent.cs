namespace Alore.Messenger.Packets.Incoming
{
    using Alore.API;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.Messenger.Packets.Outgoing;
    using System.Threading.Tasks;

    internal static class MessengerInitMessageEvent
    {
        internal static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            await session.WriteAndFlushAsync(new MessengerInitComposer());
            //TODO: Make friends.
        }
    }
}
