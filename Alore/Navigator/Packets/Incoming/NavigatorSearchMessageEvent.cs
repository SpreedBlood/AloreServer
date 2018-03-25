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

    internal static class NavigatorSearchMessageEvent
    {
        internal static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            string category = clientPacket.ReadString();
            string data = clientPacket.ReadString();

            //Send the categories..
            if (string.IsNullOrEmpty(data))
            {
                List<INavigatorCategory> categories = await controllerContext.NavigatorController.GetNavigatorCategoriesAsync();
                List<INavigatorCategory> categoriesToSend = new List<INavigatorCategory>();
                
                foreach (INavigatorCategory navCategory in categories)
                {
                    if (navCategory.Category == category)
                    {
                        categoriesToSend.Add(navCategory);
                        Console.WriteLine("Ayee");
                    }
                }
                await session.WriteAndFlushAsync(new NavigatorSearchResultSetComposer(category, data, categoriesToSend));
            }
            else //This is a search...
            {

            }
        }
    }
}
