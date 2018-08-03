namespace Alore.Room.Models
{
    using Alore.API.Room.Models;
    using System.Data.Common;

    internal class RoomModel : IRoomModel
    {
        internal RoomModel(DbDataReader reader)
        {
            Id = (string)reader["id"];
            HeightMap = (string)reader["heightmap"];
            ParseHeightMap();
        }

        private void ParseHeightMap()
        {
            string[] splitHeightMap = HeightMap.Split("\\{13}");
            MapSizeX = splitHeightMap[0].Length;
            MapSizeY = splitHeightMap.Length;
        }

        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }
        public string Id { get; set; }
        public string HeightMap { get; set; }
    }
}
