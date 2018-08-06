namespace Alore.API.Room.Grid.Pathfinding
{
    internal class HeapNode
    {
        internal HeapNode(Position position, float expectedCost)
        {
            Position = position;
            ExpectedCost = expectedCost;
        }

        /// <summary>
        /// The position of the current node.
        /// </summary>
        public Position Position { get; }

        /// <summary>
        /// The expected cost of the current node.
        /// </summary>
        public float ExpectedCost { get; set; }

        /// <summary>
        /// The next node.
        /// </summary>
        public HeapNode Next { get; set; }
    }
}
