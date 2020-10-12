using Alore.API.Network;
using Alore.API.Network.Packets;

namespace Alore.Room.Packets.Incoming.Args
{
    public class FlatConnectionArgs : IPacketArgs
    {
        internal int RoomId { get; private set; }

        internal string Password { get; private set; }

        public void Parse(IClientPacket clientPacket)
        {
            RoomId = clientPacket.ReadInt();
            Password = clientPacket.ReadString();
        }
    }
}