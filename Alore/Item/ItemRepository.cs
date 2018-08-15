namespace Alore.Item
{
    using Alore.API.Item.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class ItemRepository
    {
        private readonly ItemDao _itemDao;
        private readonly IDictionary<uint, ICollection<IItem>> _cachedUserItems;
        private readonly IDictionary<uint, IItemTemplate> _idToItemTemplates;

        public ItemRepository(ItemDao itemDao)
        {
            _itemDao = itemDao;

            _cachedUserItems = new Dictionary<uint, ICollection<IItem>>();
            _idToItemTemplates = new Dictionary<uint, IItemTemplate>();

            LoadItemTemplates();
        }

        private async void LoadItemTemplates()
        {
            IEnumerable<IItemTemplate> items = await _itemDao.GetItemTemplates();
            foreach (IItemTemplate itemTemplates in items)
            {
                _idToItemTemplates.Add(itemTemplates.Id, itemTemplates);
            }
        }

        internal async Task<IEnumerable<IItem>> GetItemsForPlayer(uint playerId)
        {
            //Get the cached entry & remove it for recaching upon client closing.
            if (_cachedUserItems.Remove(playerId))
            {
                return _cachedUserItems[playerId];
            }

            //Get a fresh version from the database & initialize the templates.
            ICollection<IItem> items = await _itemDao.GetItemsForPlayerAsync(playerId);
            foreach (IItem item in items)
            {
                if (_idToItemTemplates.TryGetValue(item.ItemData.SpriteId, out IItemTemplate template))
                {
                    item.ItemTemplate = template;
                }
            }

            return items;
        }

        //Cache the items.
        internal void CacheItems(uint userId, ICollection<IItem> items) =>
            _cachedUserItems.Add(userId, items);
    }
}