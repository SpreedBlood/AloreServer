namespace Alore.API.Room.Models
{
    public interface IRoom
    {
        /// <summary>
        /// The room data associated with the current room instance.
        /// </summary>
        IRoomData RoomData { get; set; }

        /// <summary>
        /// The room model that the room instance is using.
        /// </summary>
        IRoomModel RoomModel { get; set; }
    }
}