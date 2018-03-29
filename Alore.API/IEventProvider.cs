using Alore.API.Network.Clients;
using Alore.API.Network.Packets;

namespace Alore.API
{
    public interface IEventProvider
    {
        void TriggerEvent(ISession session, IClientPacket clientPacket);
    }
}