namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class FurnitureAliasesComposer : ServerPacket
    {
        public FurnitureAliasesComposer()
            : base(Headers.FurnitureAliasesMessageComposer)
        {
            WriteInt(0);
        }
    }
}
