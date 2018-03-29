namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class ScrGetUserInfoMessageEvent : IAsyncPacket
    {
        public short Header { get; } = 3796;

        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            await session.WriteAndFlushAsync(new ScrSendUserInfoComposer());
        }
    }
}