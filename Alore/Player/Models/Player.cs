namespace Alore.Player.Models
{
    using API.Player.Models;
    using API.Sql;
    using System.Data.Common;

    internal class Player : IPlayer
    {
        internal Player(DbDataReader reader)
        {
            Id = reader.Read<uint>("id");
            Credits = reader.Read<int>("credits");
            Duckets = reader.Read<int>("duckets");
            Diamonds = reader.Read<int>("diamonds");
            Rank = reader.Read<int>("rank");
            Username = reader.Read<string>("username");
            SsoTicket = reader.Read<string>("auth_ticket");
            Figure = reader.Read<string>("figure");
            Gender = reader.Read<string>("gender");
            Motto = reader.Read<string>("motto");
        }

        public uint Id { get; set; }
        public int Credits { get; set; }
        public int Duckets { get; set; }
        public int Diamonds { get; set; }
        public int Rank { get; set; }
        public string Username { get; set; }
        public string SsoTicket { get; set; }
        public string Figure { get; set; }
        public string Gender { get; set; }
        public string Motto { get; set; }
    }
}