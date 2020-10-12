using Alore.Handshake.Packets.Incoming.Args;

namespace Alore.Handshake.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    public class UniqueIdMessageEvent : AbstractAsyncPacket<UniqueIdArgs>
    {
        public override short Header { get; } = 3465;

        protected override async Task HandleAsync(ISession session, UniqueIdArgs args)
        {
            session.UniqueId = args.UniqueId;
            await session.WriteAndFlushAsync(new SetUniqueIdComposer(args.UniqueId));
        }
    }
}