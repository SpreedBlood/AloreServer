namespace Alore.Navigator.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class NavigatorMetaDataParserComposer : ServerPacket
    {
        public NavigatorMetaDataParserComposer()
            : base(Headers.NavigatorMetaDataParserMessageComposer)
        {
            WriteInt(0);
        }
    }
}
