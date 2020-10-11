namespace Alore.Player.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class BuildersClubMembershipComposer : ServerPacket
    {
        public BuildersClubMembershipComposer()
            : base(Headers.BuildersClubMembershipMessageComposer)
        {
            WriteInt(int.MaxValue);
            WriteInt(100);
            WriteInt(0);
            WriteInt(int.MaxValue);
        }
    }
}
