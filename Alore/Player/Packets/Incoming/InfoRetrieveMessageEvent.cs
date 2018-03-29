namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Player.Models;
    using API;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class InfoRetrieveMessageEvent : IAsyncPacket
    {
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            IPlayerStats playerStats =
                await controllerContext.PlayerController.GetPlayerStatsByIdAsync(session.Player.Id);
            if (playerStats == null)
            {
                await controllerContext.PlayerController.AddPlayerStatsAsync(session.Player.Id);
                playerStats = await controllerContext.PlayerController.GetPlayerStatsByIdAsync(session.Player.Id);
            }

            session.PlayerStats = playerStats;

            await session.WriteAndFlushAsync(new UserObjectComposer(session.Player, session.PlayerStats));
            await session.WriteAndFlushAsync(new UserPerksComposer());
        }
    }
}