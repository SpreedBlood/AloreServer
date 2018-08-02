namespace Alore.Player.Models
{
    using API.Player.Models;
    using System.Data.Common;

    internal class Player : IPlayer
    {
        internal Player(DbDataReader reader)
        {
            Id = (uint)reader["id"];
            Credits = (int)reader["credits"];
            Duckets = (int)reader["duckets"];
            Diamonds = (int)reader["diamonds"];
            Rank = (int)reader["rank"];
            Username = (string)reader["username"];
            SsoTicket = (string)reader["auth_ticket"];
            Figure = (string)reader["figure"];
            Gender = (string)reader["gender"];
            Motto = (string)reader["motto"];
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