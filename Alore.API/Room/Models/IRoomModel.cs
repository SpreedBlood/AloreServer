namespace Alore.API.Room.Models
{
    public interface IRoomModel
    {
        /// <summary>
        /// The map size in the x-axis of the room model.
        /// </summary>
        int MapSizeX { get; set; }

        /// <summary>
        /// The map size in the y-axis of the room model.
        /// </summary>
        int MapSizeY { get; set; }

        /// <summary>
        /// The model name to identify the room model.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The raw height map of the room model.
        /// </summary>
        string HeightMap { get; set; }
    }
}
