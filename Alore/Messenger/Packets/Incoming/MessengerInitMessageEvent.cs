namespace Alore.Messenger.Packets.Incoming
{
    using System.Threading.Tasks;
    using API;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class MessengerInitMessageEvent : IAsyncPacket
    {
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            await session.WriteAndFlushAsync(new MessengerInitComposer());
            //TODO: Make friends.    
        }
    }
}