namespace Alore.API.Player
{
    using System.Threading.Tasks;
    using Models;

    public interface IPlayerController
    {
        /// <summary>
        /// Get the player model by id. If cached it'll return cached version,
        /// else it will fetch from database.
        /// </summary>
        /// <param name="id">The unique id from the player.</param>
        /// <returns>The player upon task completion</returns>
        Task<IPlayer> GetPlayerByIdAsync(uint id);

        /// <summary>
        /// Fetch the player model from the database.
        /// </summary>
        /// <param name="sso">The single sign on ticket associated with the player.</param>
        /// <returns>The player upon task completion</returns>
        Task<IPlayer> GetPlayerBySsoAsync(string sso);

        /// <summary>
        /// Get the player settings by player id.
        /// </summary>
        /// <param name="id">the players id.</param>
        /// <returns>The player settings upon task completion.</returns>
        Task<IPlayerSettings> GetPlayerSettingsByIdAsync(uint id);

        /// <summary>
        /// Create the player settings column for the player.
        /// </summary>
        /// <param name="id">The players id</param>
        /// <returns>The task upon completion</returns>
        Task AddPlayerSettingsAsync(uint id);

        /// <summary>
        /// Create the player stats column for the player.
        /// </summary>
        /// <param name="id">The players id</param>
        /// <returns>The task upon completion</returns>
        Task AddPlayerStatsAsync(uint id);

        /// <summary>
        /// Fetch the player stats data.
        /// </summary>
        /// <param name="id">The players id.</param>
        /// <returns>The player stats upon completion</returns>
        Task<IPlayerStats> GetPlayerStatsByIdAsync(uint id);
    }
}