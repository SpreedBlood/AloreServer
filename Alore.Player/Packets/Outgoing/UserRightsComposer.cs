namespace Alore.Player.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class UserRightsComposer : ServerPacket
    {
        public UserRightsComposer(int rank)
            : base(Headers.UserRightsMessageComposer)
        {
            //TODO: Ambassadors, habbo club.
            WriteInt(2);
            WriteInt(rank);
            WriteBoolean(false); //Is an ambassador
        }
    }
}
