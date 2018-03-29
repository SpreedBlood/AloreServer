using System.Threading.Tasks;
using Alore.API.Network.Clients;
using Alore.API.Network.Packets;

namespace Alore.API
{
    public interface IEventProvider
    {
        Task TriggerEvent(ISession session, IClientPacket clientPacket);
    }
}