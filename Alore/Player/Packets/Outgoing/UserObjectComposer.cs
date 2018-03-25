namespace Alore.Player.Packets.Outgoing
{
    using API.Network.Packets;
    using API.Player.Models;

    public class UserObjectComposer : ServerPacket
    {
        public UserObjectComposer(IPlayer player, IPlayerStats playerStats)
            : base(Headers.UserObjectMessageComposer)
        {
            WriteInt(player.Id);
            WriteString(player.Username);
            WriteString(player.Figure);
            WriteString(player.Gender);
            WriteString(player.Motto);
            WriteString(""); //TODO: Find out what this is.
            WriteBoolean(false); //TODO:
            WriteInt(playerStats.Respect);
            WriteInt(playerStats.DailyRespect);
            WriteInt(playerStats.DailyPetPoints);
            WriteBoolean(false); //Friends stream?
            WriteString("Last online...");
            WriteBoolean(true); //Can change name.
            WriteBoolean(false);
        }
    }
}
