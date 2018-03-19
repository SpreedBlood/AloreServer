namespace Alore.Navigator.Packets.Outgoing
{
    using Alore.API.Network.Packets;
    using Alore.API.Player.Models;

    public class NavigatorPreferencesComposer : ServerPacket
    {
        public NavigatorPreferencesComposer(IPlayerSettings playerSettings)
            : base(Headers.NavigatorPreferencesMessageComposer)
        {
            WriteInt(playerSettings.NaviX);
            WriteInt(playerSettings.NaviY);
            WriteInt(playerSettings.NaviWidth);
            WriteInt(playerSettings.NaviHeight);
            WriteBoolean(playerSettings.NaviHideSearches);
            WriteInt(0); //No idea?
        }
    }
}
