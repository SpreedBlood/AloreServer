namespace Alore.Navigator.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Navigator;
    using API.Navigator.Models;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class GetNavigatorFlatsMessageEvent : IAsyncPacket
    {
        private readonly INavigatorController _navigatorController;

        internal GetNavigatorFlatsMessageEvent(INavigatorController navigatorController)
        {
            _navigatorController = navigatorController;
        }

        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            List<INavigatorCategory> eventCategories =
                await _navigatorController.GetEventCategoriesAsync();

            await session.WriteAndFlushAsync(new NavigatorFlatCatsComposer(
                eventCategories, session.Player.Rank));
        }
    }
}