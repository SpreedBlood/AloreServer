namespace Alore.Player
{
    using API;
    using Packets.Incoming;

    internal class PlayerService : IService
    {
        public void Initialize(IControllerContext context)
        {
            context.PlayerController = new PlayerController(new PlayerRepostiory(new PlayerDao()));
        }

        public void AddEvents(IEventProvider eventProvider)
        {
            eventProvider.Events.Add(1930, new SsoTicketMessageEvent());
            eventProvider.Events.Add(3092, new InfoRetrieveMessageEvent());
            eventProvider.Events.Add(2109, new GetCreditsInfoMessageEvent());
            eventProvider.Events.Add(3796, new ScrGetUserInfoMessageEvent());
        }
    }
}
