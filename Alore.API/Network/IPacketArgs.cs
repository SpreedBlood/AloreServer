using Alore.API.Network.Packets;

namespace Alore.API.Network
{
    public interface IPacketArgs
    {
        void Parse(IClientPacket clientPacket);
    }
}