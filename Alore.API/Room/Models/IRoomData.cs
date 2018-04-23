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
    }
}