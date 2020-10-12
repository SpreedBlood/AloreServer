namespace Alore.Navigator.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal class InitializeNewNavigatorMessageEvent : AbstractAsyncPacket
    {
        public override short Header { get; } = 2142;

        protected override async Task HandleAsync(ISession session)
        {
            await session.WriteAndFlushAsync(new NavigatorMetaDataParserComposer());
            await session.WriteAndFlushAsync(new NavigatorLiftedRoomsComposer());
            await session.WriteAndFlushAsync(new NavigatorCollapsedCategoriesComposer());
            await session.WriteAndFlushAsync(new NavigatorPreferencesComposer(session.PlayerSettings));
        }
    }
}