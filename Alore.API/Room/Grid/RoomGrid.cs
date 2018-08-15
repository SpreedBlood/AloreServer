namespace Alore.API.Room.Grid
{
    using Alore.API.Room.Models;
    using System.Collections.Generic;

    public class RoomGrid
    {
        public int MapSizeX { get; }
        public int MapSizeY { get; }
        public bool[,] WalkableGrid { get; }

        private readonly IDictionary<int, RoomTile> _roomTiles;

        public RoomGrid(IRoomModel roomModel)
        {
            MapSizeX = roomModel.MapSizeX;
            MapSizeY = roomModel.MapSizeY;

            _roomTiles = new Dictionary<int, RoomTile>();
            WalkableGrid = new bool[MapSizeX, MapSizeY];
            for (int y = 0; y < MapSizeY; y++)
            {
                for (int x = 0; x < MapSizeX; x++)
                {
                    WalkableGrid[x, y] = roomModel.GetTileState(x, y);
                    _roomTiles.Add(ConvertTo1D(x, y), new RoomTile());
                }
            }
        }

        public bool TryGetRoomTile(int x, int y, out RoomTile roomTile) =>
            _roomTiles.TryGetValue(ConvertTo1D(x, y), out roomTile);

        public RoomTile GetRoomTile(int x, int y) =>
            _roomTiles[ConvertTo1D(x, y)];
        
        /// <summary>
        /// Converts the x & y to a 1d index.
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">the y coordinate</param>
        /// <returns>The 1d index</returns>
        internal int ConvertTo1D(int x, int y) => MapSizeX * y + x;
    }
}
