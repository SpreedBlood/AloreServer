namespace Alore.Navigator.Packets.Incoming
{
    using Alore.API;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.Navigator.Packets.Outgoing;
    using System.Threading.Tasks;

    public static class GetUserFlatCatsMessageEvent
    {
        public static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            await session.WriteAndFlushAsync(new UserFlatCatsComposer(await controllerContext.NavigatorController.GetNavigatorCategoriesAsync(), session.Player.Rank));
        }
    }
}
