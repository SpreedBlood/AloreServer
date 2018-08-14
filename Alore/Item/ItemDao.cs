namespace Alore.Item
{
    using Alore.API.Config;
    using Alore.API.Item.Models;
    using Alore.API.Sql;
    using Alore.Item.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class ItemDao : AloreDao
    {
        public ItemDao(IConfigController configController)
            : base(configController)
        {
        }

        internal async Task<IItem> GetItemAsync(uint id)
        {
            IItem item = null;

            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        item = new Item(new ItemData(reader));
                    }
                }, "SELECT id, x, y, z FROM items WHERE id = @0", id);
            });

            return item;
        }

        internal async Task<ICollection<IItem>> GetItemsForPlayerAsync(uint playerId)
        {
            ICollection<IItem> items = new List<IItem>();

            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    while (await reader.ReadAsync())
                    {
                        items.Add(new Item(new ItemData(reader)));
                    }
                }, "SELECT id, x, y, z FROM items WHERE player_id = @0", playerId);
            });

            return items;
        }
    }
}