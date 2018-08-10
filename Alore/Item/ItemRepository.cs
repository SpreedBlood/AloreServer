namespace Alore.Item
{
    internal class ItemRepository
    {
        private readonly ItemDao _itemDao;

        public ItemRepository(ItemDao itemDao)
        {
            _itemDao = itemDao;
        }
    }
}
