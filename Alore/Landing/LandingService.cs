namespace Alore.Landing
{
    using API;
    using Packets.Incoming;

    internal class LandingService : IService
    {
        public void AddEvents(IEventProvider eventProvider, IControllerContext context)
        {
            eventProvider.Events.Add(1579, new LandingLoadWidgetMessageEvent(context.LandingController));
        }

        public void Initialize(IControllerContext context)
        {
            context.LandingController = new LandingController(new LandingRepository(new LandingDao()));
        }
    }
}
