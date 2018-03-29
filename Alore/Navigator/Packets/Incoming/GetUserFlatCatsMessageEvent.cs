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

    internal class GetUserFlatCatsMessageEvent : IAsyncPacket
    {
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            List<INavigatorCategory> categories =
                await controllerContext.NavigatorController.GetNavigatorCategoriesAsync();
            await session.WriteAndFlushAsync(new UserFlatCatsComposer(categories, session.Player.Rank));
        }
    }
}