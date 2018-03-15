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
        Task<IPlayer> GetPlayerByIdAsync(int id);

        /// <summary>
        /// Fetch the player model from the database.
        /// </summary>
        /// <param name="sso">The single sign on ticket associated with the player.</param>
        /// <returns>The player upon task completion</returns>
        Task<IPlayer> GetPlayerBySsoAsync(string sso);
    }
}