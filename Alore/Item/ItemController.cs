namespace Alore.Item
{
    using Alore.API.Item;
    using Alore.API.Item.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using Alore.API.Network.Clients;
    using Alore.Item.Models.Inventory;

    internal class ItemController : IItemController
    {
        private readonly ItemRepository _itemRepository;

        public ItemController(ItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IDictionary<uint, IItem>> GetItemsForPlayerAsync(uint playerId)
        {
            IEnumerable<IItem> items = await _itemRepository.GetItemsForPlayer(playerId);
            return items.ToDictionary(item => item.ItemData.Id, item => item);
        }

        //TODO: Make the users items cached upon disconnection.
        public void CacheItems(uint playerId, ICollection<IItem> items) =>
            _itemRepository.CacheItems(playerId, items);

        public void InitializeInventoryForSession(ISession session, IDictionary<uint, IItem> items)
        {
            session.Inventory = new Inventory(items);
        }
    }
}