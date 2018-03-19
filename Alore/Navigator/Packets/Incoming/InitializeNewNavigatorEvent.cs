using Alore.API;
using Alore.API.Network.Clients;
using Alore.API.Network.Packets;
using System.Threading.Tasks;

namespace Alore.Navigator.Packets.Incoming
{
    public static class InitializeNewNavigatorEvent
    {
        public static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
        }
    }
}
