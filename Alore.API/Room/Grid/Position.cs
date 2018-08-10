using System;

namespace Alore.API.Room.Grid
{
    public class Position : IEquatable<Position>
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

        public override bool Equals(object other)
        {
            if (other is Position position)
            {
                return position.Equals(this);
            }

            return false;
        }

        public bool Equals(Position other)
        {
            return (X == other.X && Y == other.Y);
        }

        public static bool operator ==(Position first, Position compare)
        {
            return first.Equals(compare);
        }

        public static bool operator !=(Position first, Position compare)
        {
            return !first.Equals(compare);
        }

        public static Position operator +(Position a, Position b)
        {
            return new Position(a.X + b.X, a.Y + b.Y, 0);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Y;
            }
        }

        public static int CalculateDirection(Position oldPos, Position newPos) =>
            CalculateDirection(oldPos.X, oldPos.Y, newPos.X, newPos.Y);

        public static int CalculateDirection(int x, int y, int x2, int y2)
        {
            if (x > x2)
            {
                if (y == y2)
                    return 6;
                else if (y < y2)
                    return 5;
                else
                    return 7;
            }
            else if (x < x2)
            {
                if (y == y2)
                    return 2;
                else if (y < y2)
                    return 3;
                else
                    return 1;
            }
            else
            {
                if (y < y2)
                    return 4;
                else
                    return 0;
            }
        }
    }
}