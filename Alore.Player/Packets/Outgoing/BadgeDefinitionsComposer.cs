namespace Alore.Player.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class BadgeDefinitionsComposer : ServerPacket
    {
        public BadgeDefinitionsComposer()
            : base(Headers.BadgeDefinitionsMessageComposer)
        {
            WriteInt(0);
        }
    }
}
