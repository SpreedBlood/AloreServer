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

    internal class GetUserFlatCatsMessageEvent : IAsyncPacket
    {
        public short Header { get; } = 3976;

        private readonly INavigatorController _navigatorController;
        
        public GetUserFlatCatsMessageEvent(INavigatorController navigatorController)
        {
            _navigatorController = navigatorController;
        }
        
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            IList<INavigatorCategory> categories =
                await _navigatorController.GetNavigatorCategoriesAsync();
            await session.WriteAndFlushAsync(new UserFlatCatsComposer(categories, session.Player.Rank));
        }
    }
}