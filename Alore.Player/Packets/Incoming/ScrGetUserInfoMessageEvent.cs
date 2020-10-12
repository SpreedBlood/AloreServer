namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal class ScrGetUserInfoMessageEvent : AbstractAsyncPacket
    {
        public override short Header { get; } = 3796;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new ScrSendUserInfoComposer());
        }
    }
}