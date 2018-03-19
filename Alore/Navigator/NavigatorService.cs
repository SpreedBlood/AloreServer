namespace Alore.Navigator
{
    using Alore.API;
    using Alore.Navigator.Packets.Incoming;

    public class NavigatorService : IService
    {
        public void AddEvents(IEventProvider eventProvider)
        {
            eventProvider.Events.Add(2142, InitializeNewNavigatorEvent.Execute);
        }

        public void Initialize(IControllerContext context)
        {
        }
    }
}
