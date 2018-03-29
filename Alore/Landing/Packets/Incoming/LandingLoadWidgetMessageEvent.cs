namespace Alore.Landing.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Landing.Models;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class LandingLoadWidgetMessageEvent : IAsyncPacket
    {
        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket,
            IControllerContext controllerContext)
        {
            string text = clientPacket.ReadString();
            string[] splitText = text.Split(',');
            List<IHallOfFamer> hallOfFamers = await controllerContext.LandingController.GetHallOfFamersAsync();

            if (string.IsNullOrEmpty(text) || splitText.Length < 2)
            {
                await session.WriteAndFlushAsync(new CampaignComposer("", ""));
                await session.WriteAndFlushAsync(new HallOfFameComposer(hallOfFamers, ""));
                return;
            }

            if (splitText[1] == "gamesmaker") return;

            await session.WriteAndFlushAsync(new CampaignComposer(text, splitText[1]));
            await session.WriteAndFlushAsync(new HallOfFameComposer(hallOfFamers, ""));
        }
    }
}