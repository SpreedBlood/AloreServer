namespace Alore.API.Room.Grid
{
    using Alore.API.Room.Models;

    public class RoomGrid
    {
        public int MapSizeX { get; }
        public int MapSizeY { get; }
        public bool[,] WalkableGrid { get; }

        public RoomGrid(IRoomModel roomModel)
        {
            MapSizeX = roomModel.MapSizeX;
            MapSizeY = roomModel.MapSizeY;

            WalkableGrid = new bool[MapSizeX, MapSizeY];
            for (int y = 0; y < MapSizeY; y++)
            {
                for (int x = 0; x < MapSizeX; x++)
                {
                    WalkableGrid[x, y] = roomModel.GetTileState(x, y);
                }
            }
        }
    }
}
