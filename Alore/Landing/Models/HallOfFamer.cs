namespace Alore.Landing.Models
{
    using Alore.API.Landing.Models;
    using Alore.API.Sql;

    public class HallOfFamer : AloreModel, IHallOfFamer
    {
        [AloreColumn("id")]
        public uint Id { get; set; }

        [AloreColumn("rank")]
        public int Rank { get; set; }

        [AloreColumn("diamonds")]
        public int Diamonds { get; set; }

        [AloreColumn("username")]
        public string Username { get; set; }

        [AloreColumn("figure")]
        public string Figure { get; set; }
    }
}
