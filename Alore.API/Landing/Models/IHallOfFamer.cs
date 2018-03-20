namespace Alore.API.Landing.Models
{
    public interface IHallOfFamer
    {
        /// <summary>
        /// The user id associated with the hall of famer.
        /// </summary>
        uint Id { get; set; }

        /// <summary>
        /// The hall of famers rank.
        /// </summary>
        int Rank { get; set; }

        /// <summary>
        /// The hall of famers diamonds.
        /// </summary>
        int Diamonds { get; set; }

        /// <summary>
        /// The hall of famers username.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// The hall of famers figure.
        /// </summary>
        string Figure { get; set; }
    }
}
