namespace Alore.Landing.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Landing;
    using API.Landing.Models;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Outgoing;

    internal class LandingLoadWidgetMessageEvent : IAsyncPacket
    {
        public short Header { get; } = 1579;

        private readonly ILandingController _landingController;

        public LandingLoadWidgetMessageEvent(ILandingController landingController)
        {
            _landingController = landingController;
        }

        public async Task HandleAsync(
            ISession session,
            IClientPacket clientPacket)
        {
            string text = clientPacket.ReadString();
            string[] splitText = text.Split(',');
            IList<IHallOfFamer> hallOfFamers = await _landingController.GetHallOfFamersAsync();

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