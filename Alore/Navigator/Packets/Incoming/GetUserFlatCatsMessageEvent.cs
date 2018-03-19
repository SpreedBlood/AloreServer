namespace Alore.Navigator.Packets.Incoming
{
    using Alore.API;
    using Alore.API.Navigator.Models;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.Navigator.Packets.Outgoing;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class GetUserFlatCatsMessageEvent
    {
        public static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            List<INavigatorCategory> categories = await controllerContext.NavigatorController.GetNavigatorCategoriesAsync();
            if (categories == null) return;
            await session.WriteAndFlushAsync(new UserFlatCatsComposer(categories, session.Player.Rank));
        }
    }
}
