namespace Alore.API.Room.Grid
{
    public class Position
    {
        public Position(int x, int y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// The x coordinate of the position.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// The y coordinate of the position.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// The z coordinate of the position.
        /// </summary>
        public double Z { get; set; }
    }
}
