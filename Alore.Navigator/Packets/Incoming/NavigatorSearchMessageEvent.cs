using Alore.Navigator.Packets.Incoming.Args;

namespace Alore.Navigator.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Navigator;
    using API.Navigator.Models;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal class NavigatorSearchMessageEvent : AbstractAsyncPacket<NavigatorSearchArgs>
    {
        public override short Header { get; } = 3612;

        private readonly INavigatorController _navigatorController;

        public NavigatorSearchMessageEvent(INavigatorController navigatorController)
        {
            _navigatorController = navigatorController;
        }

        protected override async Task HandleAsync(ISession session, NavigatorSearchArgs args)
        {
            //Send the categories..
            if (string.IsNullOrEmpty(args.Data))
            {
                IList<INavigatorCategory> categories =
                    await _navigatorController.GetNavigatorCategoriesAsync();
                IList<INavigatorCategory> categoriesToSend = new List<INavigatorCategory>();

                foreach (INavigatorCategory navCategory in categories)
                {
                    if (navCategory.Category == args.Category)
                    {
                        categoriesToSend.Add(navCategory);
                    }
                }

                await session.WriteAndFlushAsync(
                    new NavigatorSearchResultSetComposer(args.Category, args.Data, categoriesToSend));
            }
        }
    }
}