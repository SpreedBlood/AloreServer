namespace Alore.Messenger
{
    using Alore.Messenger.Packets.Incoming;
    using API;

    internal class MessengerService : IService
    {
        public void Initialize(IControllerContext context)
        {
        }

        public void AddEvents(IEventProvider eventProvider)
        {
            eventProvider.Events.Add(1405, MessengerInitMessageEvent.Execute);
        }
    }
}
