using Alore.API.Network.Packets;

namespace Alore.Room.Packets.Outgoing
{
    public class CloseConnectionComposer : ServerPacket
    {
        public CloseConnectionComposer()
            : base(Headers.CloseConnectionMessageComposer)
        {
        }
    }
}
