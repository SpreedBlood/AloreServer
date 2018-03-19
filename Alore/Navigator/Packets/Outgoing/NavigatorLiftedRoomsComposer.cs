namespace Alore.Navigator.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class NavigatorLiftedRoomsComposer : ServerPacket
    {
        public NavigatorLiftedRoomsComposer()
            : base(Headers.NavigatorLiftedRoomsMessageComposer)
        {
            WriteInt(0); //Count
            {
                WriteInt(1); //Flat Id
                WriteInt(0); //Unknown
                WriteString(""); //Image
                WriteString("Caption"); //Caption.
            }
        }
    }
}
