using Alore.API.Network;
using Alore.API.Network.Packets;

namespace Alore.HotelView.Packets.Incoming.Args
{
    public class LandingArgs : IPacketArgs
    {
        public string Text { get; private set; }

        public void Parse(IClientPacket clientPacket)
        {
            Text = clientPacket.ReadString();
        }
    }
}