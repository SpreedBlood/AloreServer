namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class FloorHeightMapComposer : ServerPacket
    {
        public FloorHeightMapComposer(int wallHeight, string map)
            : base(Headers.FloorHeightMapMessageComposer)
        {
            WriteBoolean(false);
            WriteInt(wallHeight); //TODO: Wallheight, once Floor Map is being done.
            WriteString(map);
        }
    }
}
