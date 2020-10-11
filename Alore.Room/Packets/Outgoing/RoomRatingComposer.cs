namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class RoomRatingComposer : ServerPacket
    {
        public RoomRatingComposer(int rating)
            : base(Headers.RoomRatingMessageComposer)
        {
            WriteInt(rating);
            WriteBoolean(false);
        }
    }
}
