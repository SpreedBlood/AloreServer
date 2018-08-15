namespace Alore.Item.Models
{
    using Alore.API.Item.Models;

    internal class Item : IItem
    {
        public IItemData ItemData { get; }

        public IItemTemplate ItemTemplate { get; set; }

        internal Item(IItemData itemData)
        {
            ItemData = itemData;
        }
    }
}
