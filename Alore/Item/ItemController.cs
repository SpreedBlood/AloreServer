namespace Alore.Item
{
    using Alore.API.Item;

    internal class ItemController : IItemController
    {
        private readonly ItemRepository _itemRepository;

        public ItemController(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
    }
}
