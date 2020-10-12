namespace Alore.Navigator.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Navigator;
    using API.Navigator.Models;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal class GetNavigatorFlatsMessageEvent : AbstractAsyncPacket
    {
        public override short Header { get; } = 708;

        private readonly INavigatorController _navigatorController;

        public GetNavigatorFlatsMessageEvent(INavigatorController navigatorController)
        {
            _navigatorController = navigatorController;
        }

        protected override async Task HandleAsync(ISession session)
        {
            IList<INavigatorCategory> eventCategories =
                await _navigatorController.GetEventCategoriesAsync();

            await session.WriteAndFlushAsync(new NavigatorFlatCatsComposer(
                eventCategories, session.Player.Rank));
        }
    }
}