using Alore.API.Network;
using Alore.API.Network.Packets;

namespace Alore.Navigator.Packets.Incoming.Args
{
    public class NavigatorSearchArgs : IPacketArgs
    {
        internal string Category { get; private set; }

        internal string Data { get; private set; }

        public void Parse(IClientPacket clientPacket)
        {
            Category = clientPacket.ReadString();
            Data = clientPacket.ReadString();
        }
    }
}