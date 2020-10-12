using Alore.API.Network;
using Alore.API.Network.Packets;

namespace Alore.Player.Packets.Incoming.Args
{
    public class SsoTicketArgs : IPacketArgs
    {
        internal string SsoTicket { get; private set; }

        public void Parse(IClientPacket clientPacket)
        {
            SsoTicket = clientPacket.ReadString();
        }
    }
}