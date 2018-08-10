namespace Alore.API.Room.Grid.Pathfinding
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public static class PathFinder
    {
        private static AstarPosition[] DIAG = new AstarPosition[]
        {
            new AstarPosition(-1, -1, 0),
            new AstarPosition(0, -1, 0),
            new AstarPosition(1, -1, 0),
            new AstarPosition(1, 0, 0),
            new AstarPosition(1, 1, 0),
            new AstarPosition(0, 1, 0),
            new AstarPosition(-1, 1, 0),
            new AstarPosition(-1, 0, 0)
        };

        public static IList<Position> FindPath(
            RoomGrid roomGrid,
            Position start,
            Position end)
        {
            //Initializes the binary heap and adds the start entry.
            BinaryHeap openHeap = new BinaryHeap();
            openHeap.Add(new HeapNode(start, ManhattanDistance(start, end)));

            float[,] currentCost = new float[roomGrid.MapSizeX, roomGrid.MapSizeY];
            Position[,] walkedPath = new Position[roomGrid.MapSizeX, roomGrid.MapSizeY];

            while (openHeap.HasEntry)
            {
                //Gets the lowest cost node from the heap.
                HeapNode curr = openHeap.Get();

                if (curr.Position == end)
                {
                    return BuildPath(start, end, walkedPath, roomGrid.MapSizeX);
                }
                float cost = currentCost[curr.Position.X, curr.Position.Y];
                foreach (AstarPosition option in DIAG)
                {
                    //The reason of this try&catch is because the position is incremented on every
                    //side of the current position so if you're next to the edge it will
                    //increment one above the grid. The reason this is possible is because
                    //everytime an exception is caught it's an invalid tile so it doesn't matter.
                    //TODO: Maybe make an if checking wether or not the tile is invalid? :thinking:
                    try
                    {
                        Position position = curr.Position + option;

                        if (!roomGrid.WalkableGrid[position.X, position.Y])
                            continue;

                        float newCost = cost + option.Cost;
                        float oldCost = currentCost[position.X, position.Y];
                        if (!(oldCost <= 0) && !(newCost < oldCost))
                            continue;

                        currentCost[position.X, position.Y] = newCost;
                        walkedPath[position.X, position.Y] = curr.Position;

                        float expCost = newCost + ManhattanDistance(position, end);
                        openHeap.Add(new HeapNode(position, expCost));
                    }
                    catch
                    {
                    }
                }
            }

            //No path was found.
            return null;
        }

        private static IList<Position> BuildPath(
            Position start,
            Position end,
            Position[,] walkedPath,
            int dimensionX)
        {
            List<Position> path = new List<Position> { end };
            Position current = end;
            while (current != start)
            {
                Position prev = walkedPath[current.X, current.Y];
                current = prev;
                path.Add(current);
            }

            return path;
        }

        /// <summary>
        /// Calculates the manhattan distance between the given positions.
        /// </summary>
        /// <param name="start">The start position,</param>
        /// <param name="end">The end position.</param>
        /// <returns>Returns the manhattan distance.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static float ManhattanDistance(Position start, Position end) =>
            Math.Abs(start.X - end.X) + Math.Abs(start.Y - end.Y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetIndexUnchecked(int x, int y, int dimX) =>
            dimX * y + x;
    }
}
