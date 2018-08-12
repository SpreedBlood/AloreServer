namespace Alore.Landing.Models
{
    using Alore.API.Landing.Models;
    using Alore.API.Sql;
    using System.Data.Common;

    internal class HallOfFamer : IHallOfFamer
    {
        internal HallOfFamer(DbDataReader reader)
        {
            Id = reader.ReadUint("id");
            Rank = reader.ReadInt("rank");
            Diamonds = reader.ReadInt("diamonds");
            Username = reader.ReadString("username");
            Figure = reader.ReadString("figure");
        }

        public uint Id { get; set; }
        public int Rank { get; set; }
        public int Diamonds { get; set; }
        public string Username { get; set; }
        public string Figure { get; set; }
    }
}