namespace Alore.Player.Packets.Outgoing
{
    using API.Network.Packets;

    public class AuthenticationOkComposer : ServerPacket
    {
        public AuthenticationOkComposer()
            : base(Headers.AuthenticationOkMessageComposer)
        {
        }
    }
}
