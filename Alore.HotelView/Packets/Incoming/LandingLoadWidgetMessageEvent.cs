using Alore.HotelView.Packets.Incoming.Args;

namespace Alore.HotelView.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Landing;
    using API.Landing.Models;
    using API.Network;
    using API.Network.Clients;
    using Outgoing;

    internal class LandingLoadWidgetMessageEvent : AbstractAsyncPacket<LandingArgs>
    {
        public override short Header { get; } = 1579;

        private readonly ILandingController _landingController;

        public LandingLoadWidgetMessageEvent(ILandingController landingController)
        {
            _landingController = landingController;
        }

        protected override async Task HandleAsync(ISession session, LandingArgs args)
        {
            string text = args.Text;
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