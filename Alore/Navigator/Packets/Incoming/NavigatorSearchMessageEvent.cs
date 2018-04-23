namespace Alore.Navigator.Packets.Incoming
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Navigator;
    using API.Navigator.Models;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class NavigatorSearchMessageEvent : IAsyncPacket
    {
        public short Header { get; } = 3612;

        private readonly INavigatorController _navigatorController;

        public NavigatorSearchMessageEvent(INavigatorController navigatorController)
        {
            _navigatorController = navigatorController;
        }


        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            string category = clientPacket.ReadString();
            string data = clientPacket.ReadString();

            //Send the categories..
            if (string.IsNullOrEmpty(data))
            {
                List<INavigatorCategory> categories =
                    await _navigatorController.GetNavigatorCategoriesAsync();
                List<INavigatorCategory> categoriesToSend = new List<INavigatorCategory>();

                foreach (INavigatorCategory navCategory in categories)
                {
                    if (navCategory.Category == category)
                    {
                        categoriesToSend.Add(navCategory);
                    }
                }

                await session.WriteAndFlushAsync(
                    new NavigatorSearchResultSetComposer(category, data, categoriesToSend));
            }
        }
    }
}