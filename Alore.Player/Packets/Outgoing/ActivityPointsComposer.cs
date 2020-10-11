namespace Alore.Player.Packets.Outgoing
{
    using API.Network.Packets;

    public class ActivityPointsComposer : ServerPacket
    {
        public ActivityPointsComposer(int duckets, int diamonds)
            : base(Headers.ActivityPointsMessageComposer)
        {
            WriteInt(11); //Count
            {
                WriteInt(0); //Pixels
                WriteInt(duckets);
                WriteInt(1); //Snowflakes
                WriteInt(16);
                WriteInt(2); //Hearts
                WriteInt(15);
                WriteInt(3); //Gift points
                WriteInt(14);
                WriteInt(4); //Shells
                WriteInt(13);
                WriteInt(5); //Diamonds
                WriteInt(diamonds);
                WriteInt(101); //Snowflakes
                WriteInt(10);
                WriteInt(102);
                WriteInt(0);
                WriteInt(103); //Stars
                WriteInt(0); //TODO: Some sort of event points.
                WriteInt(104); //Clouds
                WriteInt(0);
                WriteInt(105); //Diamonds
                WriteInt(0);
            }
        }
    }
}
