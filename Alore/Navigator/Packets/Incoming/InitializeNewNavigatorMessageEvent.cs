namespace Alore.Navigator.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class InitializeNewNavigatorMessageEvent : IAsyncPacket
    {
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            await session.WriteAndFlushAsync(new NavigatorMetaDataParserComposer());
            await session.WriteAndFlushAsync(new NavigatorLiftedRoomsComposer());
            await session.WriteAndFlushAsync(new NavigatorCollapsedCategoriesComposer());
            await session.WriteAndFlushAsync(new NavigatorPreferencesComposer(session.PlayerSettings));
        }
    }
}