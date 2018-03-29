namespace Alore.Navigator.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Navigator.Models;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class GetNavigatorFlatsMessageEvent : IAsyncPacket
    {
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            List<INavigatorCategory> eventCategories =
                await controllerContext.NavigatorController.GetEventCategoriesAsync();

            await session.WriteAndFlushAsync(new NavigatorFlatCatsComposer(
                eventCategories, session.Player.Rank));
        }
    }
}