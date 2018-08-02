namespace Alore.Landing.Models
{
    using Alore.API.Landing.Models;
    using System.Data.Common;

    internal class HallOfFamer : IHallOfFamer
    {
        internal HallOfFamer(DbDataReader reader)
        {
            Id = (uint)reader["id"];
            Rank = (int)reader["rank"];
            Diamonds = (int)reader["diamonds"];
            Username = (string)reader["username"];
            Figure = (string)reader["figure"];
        }

        public uint Id { get; set; }
        public int Rank { get; set; }
        public int Diamonds { get; set; }
        public string Username { get; set; }
        public string Figure { get; set; }
    }
}