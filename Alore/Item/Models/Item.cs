namespace Alore.Item.Models
{
    using Alore.API.Item.Models;

    internal class Item : IItem
    {
        public IItemData ItemData { get; }

        internal Item(IItemData itemData)
        {
            ItemData = itemData;
        }
    }
}
