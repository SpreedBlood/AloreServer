namespace Alore.API.Player.Models
{
    public interface IPlayer
    {
        /// <summary>
        /// The unique Id associated with the player.
        /// </summary>
        uint Id { get; set; }

        /// <summary>
        /// Get the players current credits.
        /// </summary>
        int Credits { get; set; }

        /// <summary>
        /// Get the players current duckets.
        /// </summary>
        int Duckets { get; set; }

        /// <summary>
        /// Get the players current Diamonds.
        /// </summary>
        int Diamonds { get; set; }

        /// <summary>
        /// The players rank.
        /// </summary>
        int Rank { get; set; }

        /// <summary>
        /// The username associated with the player.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The authentication ticket.
        /// </summary>
        string SsoTicket { get; set; }

        /// <summary>
        /// The figure of the avatar.
        /// </summary>
        string Figure { get; set; }

        /// <summary>
        /// The gender of the player.
        /// </summary>
        string Gender { get; set; }

        /// <summary>
        /// The motto of the player.
        /// </summary>
        string Motto { get; set; }
    }
}
