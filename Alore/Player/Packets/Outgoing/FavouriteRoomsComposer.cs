namespace Alore.Player.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class FavouriteRoomsComposer : ServerPacket
    {
        public FavouriteRoomsComposer()
            : base(Headers.FavouriteRoomsMessageComposer)
        {
            WriteInt(50);
            WriteInt(0);
        }
    }
}
