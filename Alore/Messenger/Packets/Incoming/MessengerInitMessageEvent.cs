namespace Alore.Messenger.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class MessengerInitMessageEvent : IAsyncPacket
    {
        public short Header { get; } = 1405;

        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            await session.WriteAndFlushAsync(new MessengerInitComposer());
            //TODO: Make friends.    
        }
    }
}