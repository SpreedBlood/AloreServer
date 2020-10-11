using Alore.API.Network.Packets;

namespace Alore.Player.Packets.Outgoing
{
    public class AvailabilityStatusComposer : ServerPacket
    {
        public AvailabilityStatusComposer()
            : base(Headers.AvailabilityStatusMessageComposer)
        {
            WriteBoolean(true);
            WriteBoolean(false);
            WriteBoolean(true);
        }
    }
}
