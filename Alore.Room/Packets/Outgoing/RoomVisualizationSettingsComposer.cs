namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class RoomVisualizationSettingsComposer : ServerPacket
    {
        public RoomVisualizationSettingsComposer(bool hideWalls, int wallThickness, int floorThicknes)
            : base(Headers.RoomVisualizationSettingsComposer)
        {
            WriteBoolean(hideWalls);
            WriteInt(wallThickness);
            WriteInt(floorThicknes);
        }
    }
}