namespace Alore.Navigator
{
    using API;
    using Packets.Incoming;

    internal class NavigatorService : IService
    {
        public void AddEvents(IEventProvider eventProvider, IControllerContext context)
        {
            eventProvider.Events.Add(2142, new InitializeNewNavigatorMessageEvent());
            eventProvider.Events.Add(3976, new GetUserFlatCatsMessageEvent(context.NavigatorController));
            eventProvider.Events.Add(708, new GetNavigatorFlatsMessageEvent(context.NavigatorController));
            eventProvider.Events.Add(3612, new NavigatorSearchMessageEvent(context.NavigatorController));
        }

        public void Initialize(IControllerContext context)
        {
            context.NavigatorController = new NavigatorController(new NavigatorRepository(new NavigatorDao()));
        }
    }
}