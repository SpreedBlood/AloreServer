namespace Alore.API.Player.Models
{
    public interface IPlayerStats
    {
        /// <summary>
        /// The amount of the respect that the player has.
        /// </summary>
        int Respect { get; set; }

        /// <summary>
        /// The daily respect points.
        /// </summary>
        int DailyRespect { get; set; }

        /// <summary>
        /// The daily pet points.
        /// </summary>
        int DailyPetPoints { get; set; }
    }
}
