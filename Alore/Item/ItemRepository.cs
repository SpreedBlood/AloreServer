namespace Alore.Item
{
    using Alore.API.Item.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class ItemRepository
    {
        private readonly ItemDao _itemDao;

        private readonly IDictionary<uint, ICollection<IItem>> _cachedUserItems;

        public ItemRepository(ItemDao itemDao)
        {
            _itemDao = itemDao;

            _cachedUserItems = new Dictionary<uint, ICollection<IItem>>();
        }

        internal async Task<IEnumerable<IItem>> GetItemsForPlayer(uint playerId)
        {
            //Get the cached entry & remove it for recaching upon client closing.
            if (_cachedUserItems.Remove(playerId))
            {
                return _cachedUserItems[playerId];
            }

            //Get a fresh version from the database.
            ICollection<IItem> items = await _itemDao.GetItemsForPlayerAsync(playerId);
            return items;
        }

        //Cache the items.
        internal void CacheItems(uint userId, ICollection<IItem> items) =>
            _cachedUserItems.Add(userId, items);
    }
}
