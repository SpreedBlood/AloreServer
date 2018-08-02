using Alore.API.Network.Packets;

namespace Alore.Room.Packets.Outgoing
{
    public class RoomReadyComposer : ServerPacket
    {
        public RoomReadyComposer(string modelName, uint roomId)
            : base(Headers.RoomReadyMessageComposer)
        {
            WriteString(modelName);
            WriteInt(roomId);
        }
    }
}
