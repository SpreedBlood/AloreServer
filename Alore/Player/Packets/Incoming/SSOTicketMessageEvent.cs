namespace Alore.Player.Packets.Incoming
{
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using API.Player;
    using API.Player.Models;
    using Outgoing;

    internal class SsoTicketMessageEvent : IAsyncPacket
    {
        public short Header { get; } = 1930;

        private readonly IPlayerController _playerController;

        public SsoTicketMessageEvent(IPlayerController playerController)
        {
            _playerController = playerController;
        }
        
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            string ssoTicket = clientPacket.ReadString();
            IPlayer player = await _playerController.GetPlayerBySsoAsync(ssoTicket);
            if (player != null)
            {
                session.Player = player;
                IPlayerSettings playerSettings =
                    await _playerController.GetPlayerSettingsByIdAsync(player.Id);

                if (playerSettings != null)
                {
                    session.PlayerSettings = playerSettings;
                }
                else
                {
                    await _playerController.AddPlayerSettingsAsync(player.Id);
                    session.PlayerSettings =
                        await _playerController.GetPlayerSettingsByIdAsync(player.Id);
                }

                await session.WriteAndFlushAsync(new AuthenticationOkComposer());
                await session.WriteAndFlushAsync(new HomeRoomComposer());
                await session.WriteAndFlushAsync(new FavouriteRoomsComposer());
                await session.WriteAndFlushAsync(new FigureSetIdsComposer());
                await session.WriteAndFlushAsync(new UserRightsComposer(session.Player.Rank));
                await session.WriteAndFlushAsync(new AvailabilityStatusComposer());
                await session.WriteAndFlushAsync(new BuildersClubMembershipComposer());
                await session.WriteAndFlushAsync(new CfhTopicsInitComposer());
                await session.WriteAndFlushAsync(new BadgeDefinitionsComposer());
                await session.WriteAndFlushAsync(new PlayerSettingsComposer());
            }
        }
    }
}