namespace Alore.Player.Models
{
    using API.Player.Models;

    public class Player : IPlayer
    {
        public int Id { get; set; }
        
        public int Credits { get; set; }

        public int Duckets { get; set; }

        public int Diamonds { get; set; }

        public string Username { get; set; }
        
        public string SsoTicket { get; set; }

        public string Figure { get; set; }

        public string Gender { get; set; }

        public string Motto { get; set; }
    }
}
