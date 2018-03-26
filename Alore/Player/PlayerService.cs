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
            eventProvider.Events.Add(1930, SsoTicketMessageEvent.Execute);
            eventProvider.Events.Add(3092, InfoRetrieveMessageEvent.Execute);
            eventProvider.Events.Add(2109, GetCreditsInfoMessageEvent.Execute);
            eventProvider.Events.Add(3796, ScrGetUserInfoMessageEvent.Execute);
        }
    }
}
