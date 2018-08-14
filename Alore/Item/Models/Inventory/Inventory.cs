namespace Alore.Item.Models.Inventory
{
    using Alore.API.Item.Models;
    using System.Collections.Generic;

    internal class Inventory : IInventory
    {
        public IDictionary<uint, IItem> Items { get; }

        internal Inventory(IDictionary<uint, IItem> items)
        {
            Items = items;
        }
        
        public bool ContainsItem(uint id) => Items.ContainsKey(id);

        public IItem GetItem(uint id) => Items[id];

        public bool TryGetItem(uint id, out IItem item) => Items.TryGetValue(id, out item);
    }
}
