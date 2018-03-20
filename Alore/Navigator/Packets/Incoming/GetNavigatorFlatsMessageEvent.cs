namespace Alore.Navigator.Packets.Incoming
{
    using Alore.API;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.Navigator.Packets.Outgoing;
    using System.Threading.Tasks;

    public static class GetNavigatorFlatsMessageEvent
    {
        public static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            await session.WriteAndFlushAsync(new NavigatorFlatCatsComposer(await controllerContext.NavigatorController.GetNavigatorPromoterCategoriesAsync(), session.Player.Rank));
        }
    }
}
