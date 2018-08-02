namespace Alore.API.Room.Models
{
    public interface IRoomData
    {
        /// <summary>
        /// The rooms unique id.
        /// </summary>
        uint Id { get; set; }
        
        /// <summary>
        /// The name of the room.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The password of the room.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// The model name of the room.
        /// </summary>
        string ModelName { get; set; }
    }
}