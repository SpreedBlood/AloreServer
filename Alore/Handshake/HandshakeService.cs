namespace Alore.Handshake
{
    using API;
    using Packets.Incoming;

    internal class HandshakeService : IService
    {
        public void Initialize(IControllerContext context)
        {
        }

        public void AddEvents(IEventProvider eventProvider)
        {
            eventProvider.Events.Add(3465, new UniqueIdMessageEvent());
        }
    }
}
