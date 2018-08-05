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
        /// Gets the direction of the door. This is used to figure out players direction
        /// upon room entry.
        /// </summary>
        int DoorDir { get; set; }

        /// <summary>
        /// The door coordinate on the x-axis.
        /// </summary>
        int DoorX { get; set; }

        /// <summary>
        /// The door coordinate on the y-axis.
        /// </summary>
        int DoorY { get; set; }

        /// <summary>
        /// The door coordinate on the z-axis.
        /// </summary>
        double DoorZ { get; set; }

        /// <summary>
        /// The model name to identify the room model.
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The raw height map of the room model.
        /// </summary>
        string HeightMap { get; set; }

        /// <summary>
        /// The relative height map of the room model.
        /// </summary>
        string RelativeHeightMap { get; set; }

        /// <summary>
        /// Gets the height of the tile at the given coordinates.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The z-index.</returns>
        double GetHeight(int x, int y);

        /// <summary>
        /// Get's the state of the tile.
        /// </summary>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        /// <returns>The state of the tile. false = invalid, true = valid.</returns>
        bool GetTileState(int x, int y);
    }
}
