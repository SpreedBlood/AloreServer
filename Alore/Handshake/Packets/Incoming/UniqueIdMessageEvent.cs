namespace Alore.Handshake.Packets.Incoming
{
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    public static class UniqueIdMessageEvent
    {
        public static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            string uniqueId = clientPacket.ReadString();
            session.UniqueId = uniqueId;
            await session.WriteAndFlushAsync(new SetUniqueIdComposer(uniqueId));
        }
    }
}
