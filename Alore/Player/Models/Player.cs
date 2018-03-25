namespace Alore.Player.Models
{
    using API.Player.Models;
    using API.Sql;

    internal class Player : AloreModel, IPlayer
    {
        [AloreColumn("id")]
        public uint Id { get; set; }

        [AloreColumn("credits")]
        public int Credits { get; set; }

        [AloreColumn("duckets")]
        public int Duckets { get; set; }

        [AloreColumn("diamonds")]
        public int Diamonds { get; set; }

        [AloreColumn("rank")]
        public int Rank { get; set; }

        [AloreColumn("username")]
        public string Username { get; set; }

        [AloreColumn("auth_ticket")]
        public string SsoTicket { get; set; }

        [AloreColumn("figure")]
        public string Figure { get; set; }

        [AloreColumn("gender")]
        public string Gender { get; set; }

        [AloreColumn("motto")]
        public string Motto { get; set; }
    }
}