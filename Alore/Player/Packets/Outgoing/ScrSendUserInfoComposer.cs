namespace Alore.Player.Packets.Outgoing
{
    using API.Network.Packets;

    public class ScrSendUserInfoComposer : ServerPacket
    {
        public ScrSendUserInfoComposer()
            : base(Headers.ScrSendUserInfoMessageComposer)
        {
            //TODO: Code habbo club.
            var displayMonths = 0;
            var displayDays = 0;

            WriteString("habbo_club");
            WriteInt(displayDays);
            WriteInt(2);
            WriteInt(displayMonths);
            WriteInt(1);
            WriteBoolean(true); // hc
            WriteBoolean(true); // vip
            WriteInt(0);
            WriteInt(0);
            WriteInt(495);
        }
    }
}