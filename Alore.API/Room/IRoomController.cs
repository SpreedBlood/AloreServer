namespace Alore.API.Room
{
    using System.Threading.Tasks;
    using Alore.API.Network.Clients;
    using Alore.API.Room.Entities;
    using Models;

    public interface IRoomController
    {
        /// <summary>
        /// Add's a user entity to the room.
        /// </summary>
        /// <param name="room">The room that is being entered.</param>
        /// <param name="session">The session associated with the user. (Pets and bots won't have a session).</param>
        /// <returns>The added user entity.</returns>
        BaseEntity AddUserToRoom(IRoom room, ISession session);

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
