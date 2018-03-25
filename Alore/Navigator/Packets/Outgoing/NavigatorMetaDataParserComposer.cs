namespace Alore.Navigator.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class NavigatorMetaDataParserComposer : ServerPacket
    {
        public NavigatorMetaDataParserComposer()
            : base(Headers.NavigatorMetaDataParserMessageComposer)
        {
            WriteInt(4);
            {
                WriteString("official_view");
                WriteInt(0);

                WriteString("hotel_view");
                WriteInt(0);

                WriteString("roomads_view");
                WriteInt(0);

                WriteString("myworld_view");
                WriteInt(0);
            }
        }
    }
}
