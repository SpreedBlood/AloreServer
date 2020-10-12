using Alore.API.Network;
using Alore.API.Network.Packets;

namespace Alore.Item.Packets.Incoming.Args
{
    public class PlaceObjectArgs : IPacketArgs
    {
        public string RawData { get; private set; }

        public void Parse(IClientPacket clientPacket)
        {
            RawData = clientPacket.ReadString();
        }
    }
}