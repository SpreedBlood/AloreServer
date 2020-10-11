namespace Alore.HotelView.Models
{
    using Alore.API.Landing.Models;
    using Alore.API.Sql;
    using System.Data.Common;

    internal class HallOfFamer : IHallOfFamer
    {
        internal HallOfFamer(DbDataReader reader)
        {
            Id = reader.Read<uint>("id");
            Rank = reader.Read<int>("rank");
            Diamonds = reader.Read<int>("diamonds");
            Username = reader.Read<string>("username");
            Figure = reader.Read<string>("figure");
        }

        public uint Id { get; set; }
        public int Rank { get; set; }
        public int Diamonds { get; set; }
        public string Username { get; set; }
        public string Figure { get; set; }
    }
}