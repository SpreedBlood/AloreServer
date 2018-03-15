namespace Alore.Player.Packets.Outgoing
{
    using API.Network.Packets;

    public class CreditBalanceComposer : ServerPacket
    {
        public CreditBalanceComposer(int credits)
            : base(Headers.CreditBalanceMessageComposer)
        {
            WriteString(credits + ".0");
        }
    }
}
