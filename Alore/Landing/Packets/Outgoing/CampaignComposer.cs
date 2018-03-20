namespace Alore.Landing.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class CampaignComposer : ServerPacket
    {
        public CampaignComposer(string campaignString, string campaignName)
            : base(Headers.CampaignMessageComposer)
        {
            WriteString(campaignString);
            WriteString(campaignName);
        }
    }
}
