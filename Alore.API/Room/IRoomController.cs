namespace Alore.API.Room
{
    using System.Threading.Tasks;
    using Models;

    public interface IRoomController
    {
        /// <summary>
        /// Gets the room instance by id upon task completion.
        /// </summary>
        /// <param name="id">The room id</param>
        /// <returns>The room instance</returns>
        Task<IRoom> GetRoomByIdAsync(int id);

        /// <summary>
        /// Gets the room instance by id and then checks if the password matches.
        /// </summary>
        /// <param name="id">The room id</param>
        /// <param name="password">The room password</param>
        /// <returns>The room if the password matches and the room exists.</returns>
        Task<IRoom> GetRoomByIdAndPassword(int id, string password);
    }
}
