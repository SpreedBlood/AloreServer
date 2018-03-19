namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using API.Player.Models;
    using Outgoing;

    public static class SsoTicketMessageEvent
    {
        public static async Task Execute(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            string ssoTicket = clientPacket.ReadString();
            IPlayer player = await controllerContext.PlayerController.GetPlayerBySsoAsync(ssoTicket);
            
            if (player != null)
            {
                session.Player = player;
                await session.WriteAndFlushAsync(new AuthenticationOkComposer());
            }
        }
    }
}