namespace Alore.Landing
{
    using Alore.API;
    using Alore.Landing.Packets.Incoming;

    internal class LandingService : IService
    {
        public void AddEvents(IEventProvider eventProvider)
        {
            eventProvider.Events.Add(1579, LandingLoadWidgetMessageEvent.Execute);
        }

        public void Initialize(IControllerContext context)
        {
            context.LandingController = new LandingController(new LandingRepository(new LandingDao()));
        }
    }
}
