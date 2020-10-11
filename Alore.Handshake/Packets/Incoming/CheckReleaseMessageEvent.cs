using System.Threading.Tasks;
using Alore.API.Network;
using Alore.API.Network.Clients;
using Alore.API.Network.Packets;

namespace Alore.Handshake.Packets.Incoming
{
    public class CheckReleaseMessageEvent : IAsyncPacket
    {
        public short Header { get; } = Headers.CheckReleaseEvent;

        public Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            string release = clientPacket.ReadString();
            
            return Task.CompletedTask;
        }
    }
}