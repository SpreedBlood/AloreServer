namespace Alore.Room.Models
{
    using Alore.API.Room.Models;
    using System.Data.Common;
    using System.Text;

    internal class RoomModel : IRoomModel
    {
        internal RoomModel(DbDataReader reader)
        {
            Id = (string)reader["id"];
            HeightMap = (string)reader["heightmap"];
            ParseHeightMap();
            ParseRelativeHeightMap();
        }

        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }
        public int DoorX { get; set; }
        public int DoorY { get; set; }
        public double DoorZ { get; set; }
        public string Id { get; set; }
        public string HeightMap { get; set; }
        public string RelativeHeightMap { get; set; }
        private double[,] floorHeightMap;

        private void ParseHeightMap()
        {
            string[] splitHeightMap = HeightMap.Split(13.ToString());
            MapSizeX = splitHeightMap[0].Length;
            MapSizeY = splitHeightMap.Length;
            floorHeightMap = new double[MapSizeX, MapSizeY];

            for (int y = 0; y < MapSizeY; y++)
            {
                string line = splitHeightMap[y];
                line = line.Replace("\r", "");
                line = line.Replace("\n", "");

                int x = 0;
                foreach (char square in line)
                {
                    if (square == 'x')
                    {
                        //Square is blocked!
                    }
                    else
                    {
                        floorHeightMap[x, y] = Parse(square);
                    }
                    x++;
                }
            }
        }

        private void ParseRelativeHeightMap()
        {
            StringBuilder relativeHeightMap = new StringBuilder();
            for (int y = 0; y < MapSizeY; y++)
            {
                for (int x = 0; x < MapSizeX; x++)
                {
                    if (x == DoorX && y == DoorY)
                    {
                        relativeHeightMap.Append(DoorZ > 9 ? (87 + DoorZ).ToString() : DoorZ.ToString());
                        continue;
                    }

                    double height = GetHeight(x, y);
                    relativeHeightMap.Append(height > 9 ? (87 + height).ToString() : height.ToString());
                }

                relativeHeightMap.Append(13.ToString());
            }

            RelativeHeightMap = relativeHeightMap.ToString();
        }

        public double GetHeight(int x, int y) =>
            floorHeightMap[x, y];

        #region Parse Method
        private static short Parse(char input)
        {

            switch (input)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'a':
                    return 10;
                case 'b':
                    return 11;
                case 'c':
                    return 12;
                case 'd':
                    return 13;
                case 'e':
                    return 14;
                case 'f':
                    return 15;
                case 'g':
                    return 16;
                case 'h':
                    return 17;
                case 'i':
                    return 18;
                case 'j':
                    return 19;
                case 'k':
                    return 20;
                case 'l':
                    return 21;
                case 'm':
                    return 22;
                case 'n':
                    return 23;
                case 'o':
                    return 24;
                case 'p':
                    return 25;
                case 'q':
                    return 26;
                case 'r':
                    return 27;
                case 's':
                    return 28;
                case 't':
                    return 29;
                case 'u':
                    return 30;
                case 'v':
                    return 31;
                case 'w':
                    return 32;

                default:
                    return 0;
            }
            #endregion
        }
    }
}
