namespace Alore.Player.Models
{
    using Alore.API.Player.Models;
    using Alore.API.Sql;

    internal class PlayerStats : AloreModel, IPlayerStats
    {
        [AloreColumn("respect")]
        public int Respect { get; set; }

        [AloreColumn("daily_respect")]
        public int DailyRespect { get; set; }

        [AloreColumn("daily_pet_points")]
        public int DailyPetPoints { get; set; }
    }
}
