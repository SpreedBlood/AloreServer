namespace Alore.Messenger.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal abstract class MessengerInitMessageEvent : AbstractAsyncPacket
    {
        public override short Header { get; } = 1405;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new MessengerInitComposer());
            //TODO: Make friends.
        }
    }
}