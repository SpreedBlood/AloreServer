using Alore.API.Network;
using Alore.API.Network.Packets;

namespace Alore.Handshake.Packets.Incoming.Args
{
    public class UniqueIdArgs : IPacketArgs
    {
        public string UniqueId { get; private set; }

        public void Parse(IClientPacket clientPacket)
        {
            UniqueId = clientPacket.ReadString();
        }
    }
}