namespace Alore.Player.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class PlayerSettingsComposer : ServerPacket
    {
        public PlayerSettingsComposer()
            : base(Headers.PlayerSettingsMessageComposer)
        {
            for (int i = 3; i >= 0; i--)
            {
                WriteInt(100);
            }

            WriteBoolean(true);
            WriteBoolean(true);
            WriteBoolean(true);
            WriteInt(0);
            WriteInt(0);
            WriteInt(0);
        }
    }
}
