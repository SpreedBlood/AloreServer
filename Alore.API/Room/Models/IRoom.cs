using Alore.API.Network.Clients;
using Alore.API.Network.Packets;
using Alore.API.Room.Entities;
using Alore.API.Room.Grid;
using Alore.API.Room.Rights;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alore.API.Room.Models
{
    public interface IRoom
    {
        /// <summary>
        /// Gets the grid of the current room. Responsible for mapping items and entities
        /// on the grid.
        /// </summary>
        RoomGrid RoomGrid { get; }

        /// <summary>
        /// The room data associated with the current room instance.
        /// </summary>
        IRoomData RoomData { get; set; }

        /// <summary>
        /// The room model that the room instance is using.
        /// </summary>
        IRoomModel RoomModel { get; set; }

        /// <summary>
        /// Gets all the entities of the room (Bots, pets, users).
        /// </summary>
        IDictionary<int, BaseEntity> Entities { get; }

        /// <summary>
        /// Tries to add the entity to the room.
        /// </summary>
        /// <param name="entity">The entity type to add.</param>
        void AddEntity(BaseEntity entity);

        /// <summary>
        /// Sends the given packet to all the player entities in the room. (NOT BOTS AND PETS).
        /// </summary>
        /// <param name="serverPacket">The packet to send.</param>
        /// <returns>The task upon completion.</returns>
        Task SendAsync(ServerPacket serverPacket);

        /// <summary>
        /// Gets the room right for the given player id.
        /// </summary>
        /// <param name="entityId">The id of the entity.</param>
        /// <returns>The room right that the entity has.</returns>
        RoomRight GetRoomRight(uint entityId);

        /// <summary>
        /// Gets the state of the cancellation token. If a cancellation is requested or not.
        /// </summary>
        bool CycleActive { get; }

        /// <summary>
        /// Starts a cycle with 500ms delay. To stop only cancel the cancellation token.
        /// </summary>
        /// <param name="taskHandler">The task handler to start the task.</param>
        void SetupRoomCycle();

        /// <summary>
        /// Stops the room cycle by cancelling the cancelation token.
        /// </summary>
        void StopRoomCycle();

        /// <summary>
        /// Makes the session leave the current room.
        /// </summary>
        /// <param name="session">The session that's trying to leave the room.</param>
        void LeaveRoom(ISession session);
    }
}