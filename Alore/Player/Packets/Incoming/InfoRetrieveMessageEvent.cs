namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Player.Models;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using API.Player;
    using Outgoing;

    internal class InfoRetrieveMessageEvent : IAsyncPacket
    {
        private readonly IPlayerController _playerController;

        internal InfoRetrieveMessageEvent(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            IPlayerStats playerStats =
                await _playerController.GetPlayerStatsByIdAsync(session.Player.Id);
            if (playerStats == null)
            {
                await _playerController.AddPlayerStatsAsync(session.Player.Id);
                playerStats = await _playerController.GetPlayerStatsByIdAsync(session.Player.Id);
            }

            session.PlayerStats = playerStats;

            await session.WriteAndFlushAsync(new UserObjectComposer(session.Player, session.PlayerStats));
            await session.WriteAndFlushAsync(new UserPerksComposer());
        }
    }
}