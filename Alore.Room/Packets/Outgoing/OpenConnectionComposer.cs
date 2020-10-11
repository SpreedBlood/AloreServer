namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class OpenConnectionComposer : ServerPacket
    {
        public OpenConnectionComposer()
            : base(Headers.OpenConnectionMessageComposer)
        {
        }
    }
}
