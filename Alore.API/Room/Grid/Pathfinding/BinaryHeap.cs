namespace Alore.API.Room.Grid.Pathfinding
{
    internal class BinaryHeap
    {
        private HeapNode head;

        internal bool HasEntry => head != null;

        internal void Add(HeapNode node)
        {
            if (head == null)
            {
                head = node;
            }
            //Replace the position of the nodes because the node to add has a lower
            //cost.
            else if (node.ExpectedCost < head.ExpectedCost)
            {
                node.Next = head;
                head = node;
            }
            //Add the node & realign the heap.
            else
            {
                HeapNode current = head;
                while (current.Next != null && current.Next.ExpectedCost <= node.ExpectedCost)
                {
                    current = current.Next;
                }

                node.Next = current.Next;
                current.Next = node;
            }
        }

        /// <summary>
        /// Get the cheapest & make the 2nd cheapest the 1st.
        /// </summary>
        /// <returns>The cheapest node in the heap.</returns>
        internal HeapNode Get()
        {
            HeapNode first = head;
            head = head.Next;

            return first;
        }
    }
}