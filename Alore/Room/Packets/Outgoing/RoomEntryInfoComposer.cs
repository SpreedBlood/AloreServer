namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class RoomEntryInfoComposer : ServerPacket
    {
        public RoomEntryInfoComposer(uint roomId, bool userIsOwner)
            : base(Headers.RoomEntryInfoMessageComposer)
        {
            WriteInt(roomId);
            WriteBoolean(userIsOwner);
        }
    }
}
