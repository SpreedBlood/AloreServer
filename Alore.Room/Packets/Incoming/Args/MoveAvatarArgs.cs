using Alore.API.Network;
using Alore.API.Network.Packets;

namespace Alore.Room.Packets.Incoming.Args
{
    public class MoveAvatarArgs : IPacketArgs
    {
        internal int X { get; private set; }

        internal int Y { get; private set; }

        public void Parse(IClientPacket clientPacket)
        {
            X = clientPacket.ReadInt();
            Y = clientPacket.ReadInt();
        }
    }
}