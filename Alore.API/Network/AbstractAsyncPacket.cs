using System.Threading.Tasks;
using Alore.API.Network.Clients;
using Alore.API.Network.Packets;

namespace Alore.API.Network
{
    public abstract class AbstractAsyncPacket<TArgs> : IAsyncPacket
        where TArgs : IPacketArgs, new()
    {
        public abstract short Header { get; }

        protected abstract Task HandleAsync(ISession session, TArgs args);

        public Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            TArgs args = new TArgs();
            args.Parse(clientPacket);

            return HandleAsync(session, args);
        }
    }

    public abstract class AbstractAsyncPacket : IAsyncPacket
    {
        public abstract short Header { get; }

        protected abstract Task HandleAsync(ISession session);

        public Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            return HandleAsync(session);
        }
    }
}