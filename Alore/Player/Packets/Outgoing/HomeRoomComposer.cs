using Alore.API.Network.Packets;

namespace Alore.Player.Packets.Outgoing
{
    public class HomeRoomComposer : ServerPacket
    {
        public HomeRoomComposer(int roomId)
            : base(Headers.HomeRoomMessageComposer)
        {
            WriteInt(roomId);
            WriteInt(roomId);
        }
    }
}
