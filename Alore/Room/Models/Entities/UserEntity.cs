namespace Alore.Room.Models.Entities
{
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Player.Models;
    using Alore.API.Room.Entities;

    internal class UserEntity : BaseEntity
    {
        internal UserEntity(int id, int x, int y, int rotation, ISession session)
            : base(id, x, y, rotation, session.Player.Username, session.Player.Figure)
        {
            Session = session;
            Motto = session.Player.Motto;
        }

        public ISession Session { get; }
        public IPlayer Player => Session.Player;
        public string Motto { get; set; }

        public override void Compose(ServerPacket serverPacket)
        {
            serverPacket.WriteInt(Player.Id);
            serverPacket.WriteString(Name);
            serverPacket.WriteString(Motto);
            serverPacket.WriteString(Figure);
            serverPacket.WriteInt(Id);
            serverPacket.WriteInt(Position.X);
            serverPacket.WriteInt(Position.Y);
            serverPacket.WriteString(Position.Z.ToString());
            serverPacket.WriteInt(0);
            serverPacket.WriteInt(1);
            serverPacket.WriteString(Player.Gender.ToLower());
            serverPacket.WriteInt(-1);
            serverPacket.WriteInt(-1);
            serverPacket.WriteInt(0);
            serverPacket.WriteInt(1337); // achievement points
            serverPacket.WriteBoolean(false);
        }
    }
}