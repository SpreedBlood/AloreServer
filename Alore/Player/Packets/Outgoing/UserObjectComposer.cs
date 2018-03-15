namespace Alore.Player.Packets.Outgoing
{
    using API.Network.Packets;
    using API.Player.Models;

    public class UserObjectComposer : ServerPacket
    {
        public UserObjectComposer(IPlayer player)
            : base(Headers.UserObjectMessageComposer)
        {
            WriteInt(player.Id);
            WriteString(player.Username);
            WriteString(player.Figure);
            WriteString(player.Gender);
            WriteString(player.Motto);
            WriteString(""); //TODO: Find out what this is.
            WriteBoolean(false); //TODO:
            WriteInt(10); //TODO: Respect.
            WriteInt(10); //TODO: Daily respect.
            WriteInt(10); //TODO: Daily pet points.
            WriteBoolean(false); //Friends stream?
            WriteString("Last online...");
            WriteBoolean(true); //Can change name.
            WriteBoolean(false);
        }
    }
}
