namespace Alore.Item
{
    using Alore.API.Item;
    using Alore.API.Item.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    internal class ItemController : IItemController
    {
        private readonly ItemRepository _itemRepository;

        public ItemController(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IDictionary<uint, IItem>> GetItemsForPlayerAsync(int playerId)
        {
            IEnumerable<IItem> items = await _itemRepository.GetItemsForPlayer(playerId);
            return items.ToDictionary(item => item.ItemData.Id, item => item);
        }

        public void CacheItems(int playerId, ICollection<IItem> items) =>
            _itemRepository.CacheItems(playerId, items);
    }
}
