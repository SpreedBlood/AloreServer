namespace Alore.Navigator
{
    using Alore.API;
    using Alore.Navigator.Packets.Incoming;

    public class NavigatorService : IService
    {
        public void AddEvents(IEventProvider eventProvider)
        {
            eventProvider.Events.Add(2142, InitializeNewNavigatorMessageEvent.Execute);
            eventProvider.Events.Add(3976, GetUserFlatCatsMessageEvent.Execute);
        }

        public void Initialize(IControllerContext context)
        {
            context.NavigatorController = new NavigatorController(new NavigatorRepository(new NavigatorDao()));
        }
    }
}