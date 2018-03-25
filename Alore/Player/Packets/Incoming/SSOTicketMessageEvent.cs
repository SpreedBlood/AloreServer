﻿namespace Alore.Player.Packets.Incoming
{
    using System;
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
                IPlayerSettings playerSettings = await controllerContext.PlayerController.GetPlayerSettingsByIdAsync(player.Id);

                if (playerSettings != null)
                {
                    session.PlayerSettings = playerSettings;
                }
                else
                {
                    await controllerContext.PlayerController.AddPlayerSettingsAsync(player.Id);
                    session.PlayerSettings = await controllerContext.PlayerController.GetPlayerSettingsByIdAsync(player.Id);
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