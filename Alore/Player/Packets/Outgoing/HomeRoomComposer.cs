using Alore.API.Network.Packets;

namespace Alore.Player.Packets.Outgoing
{
    public class HomeRoomComposer : ServerPacket
    {
        public HomeRoomComposer()
            : base(Headers.HomeRoomMessageComposer)
        {
            WriteInt(0);
            WriteInt(0);
        }
    }
}
