namespace Alore.API.Room.Grid
{
    using Alore.API.Item.Models;
    using System.Collections.Generic;

    public class RoomTile
    {
        public IList<IItem> ItemStack { get; }

        internal RoomTile()
        {
            ItemStack = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            ItemStack.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            ItemStack.Remove(item);
        }
    }
}