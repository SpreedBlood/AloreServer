namespace Alore.Navigator.Packets.Incoming
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Navigator.Models;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class NavigatorSearchMessageEvent : IAsyncPacket
    {
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            string category = clientPacket.ReadString();
            string data = clientPacket.ReadString();

            //Send the categories..
            if (string.IsNullOrEmpty(data))
            {
                List<INavigatorCategory> categories =
                    await controllerContext.NavigatorController.GetNavigatorCategoriesAsync();
                List<INavigatorCategory> categoriesToSend = new List<INavigatorCategory>();

                foreach (INavigatorCategory navCategory in categories)
                {
                    if (navCategory.Category == category)
                    {
                        categoriesToSend.Add(navCategory);
                        Console.WriteLine("Ayee");
                    }
                }

                await session.WriteAndFlushAsync(
                    new NavigatorSearchResultSetComposer(category, data, categoriesToSend));
            }
        }
    }
}