namespace Alore.Navigator.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Navigator;
    using API.Navigator.Models;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal class GetUserFlatCatsMessageEvent : AbstractAsyncPacket
    {
        public override short Header { get; } = 3976;

        private readonly INavigatorController _navigatorController;

        public GetUserFlatCatsMessageEvent(INavigatorController navigatorController)
        {
            _navigatorController = navigatorController;
        }

        protected override async Task HandleAsync(ISession session)
        {
            IList<INavigatorCategory> categories =
                await _navigatorController.GetNavigatorCategoriesAsync();
            await session.WriteAndFlushAsync(new UserFlatCatsComposer(categories, session.Player.Rank));
        }
    }
}