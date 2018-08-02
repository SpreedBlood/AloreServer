namespace Alore.Player.Models
{
    using Alore.API.Player.Models;
    using System.Data.Common;

    internal class PlayerStats : IPlayerStats
    {
        internal PlayerStats(DbDataReader reader)
        {
            Respect = (int)reader["respect"];
            DailyRespect = (int)reader["daily_respect"];
            DailyPetPoints = (int)reader["daily_pet_points"];
        }
        
        public int Respect { get; set; }
        public int DailyRespect { get; set; }
        public int DailyPetPoints { get; set; }
    }
}
