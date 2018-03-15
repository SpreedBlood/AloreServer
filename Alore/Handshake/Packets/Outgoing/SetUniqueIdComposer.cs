namespace Alore.Handshake.Packets.Outgoing
{
    using API.Network.Packets;

    public class SetUniqueIdComposer : ServerPacket
    {
        public SetUniqueIdComposer(string uniqueId)
            : base(Headers.SetUniqueIdComposer)
        {
            WriteString(uniqueId);
        }
    }
}
