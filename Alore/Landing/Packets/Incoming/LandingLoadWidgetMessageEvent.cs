namespace Alore.Landing.Packets.Incoming
{
    using Alore.API;
    using Alore.API.Landing.Models;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.Landing.Packets.Outgoing;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class LandingLoadWidgetMessageEvent
    {
        public static async Task Execute(
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
