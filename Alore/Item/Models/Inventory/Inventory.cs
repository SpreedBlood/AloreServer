namespace Alore.Item.Models.Inventory
{
    using Alore.API.Item.Models;
    using System.Collections.Generic;

    internal class Inventory : IInventory
    {
        private IDictionary<uint, IItem> _items;

        internal Inventory(IDictionary<uint, IItem> items)
        {
            _items = items;
        }
        
        public bool ContainsItem(uint id) => _items.ContainsKey(id);

        public IItem GetItem(uint id) => _items[id];

        public bool TryGetItem(uint id, out IItem item) => _items.TryGetValue(id, out item);
    }
}
