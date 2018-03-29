namespace Alore.Navigator
{
    using API;
    using Packets.Incoming;

    internal class NavigatorService : IService
    {
        public void AddEvents(IEventProvider eventProvider)
        {
            eventProvider.Events.Add(2142, new InitializeNewNavigatorMessageEvent());
            eventProvider.Events.Add(3976, new GetUserFlatCatsMessageEvent());
            eventProvider.Events.Add(708, new GetNavigatorFlatsMessageEvent());
            eventProvider.Events.Add(3612, new NavigatorSearchMessageEvent());
        }

        public void Initialize(IControllerContext context)
        {
            context.NavigatorController = new NavigatorController(new NavigatorRepository(new NavigatorDao()));
        }
    }
}