using Alore.API.Network;
using Alore.API.Network.Packets;

namespace Alore.Handshake.Packets.Incoming.Args
{
    public class ReleaseArgs : IPacketArgs
    {
        public string Release { get; private set; }

        public void Parse(IClientPacket clientPacket)
        {
            Release = clientPacket.ReadString();
        }
    }
}