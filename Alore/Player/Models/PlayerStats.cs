namespace Alore.Player.Models
{
    using Alore.API.Player.Models;
    using Alore.API.Sql;
    using System.Data.Common;

    internal class PlayerStats : IPlayerStats
    {
        internal PlayerStats(DbDataReader reader)
        {
            Respect = reader.Read<int>("respect");
            DailyRespect = reader.Read<int>("daily_respect");
            DailyPetPoints = reader.Read<int>("daily_pet_points");
        }
        
        public int Respect { get; set; }
        public int DailyRespect { get; set; }
        public int DailyPetPoints { get; set; }
    }
}
