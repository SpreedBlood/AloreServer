namespace Alore.API.Item
{
    using Alore.API.Item.Models;
    using Alore.API.Network.Clients;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IItemController
    {
        /// <summary>
        /// Gets all the items from the database and stores it in a dictionary where the key is,
        /// the item id.
        /// </summary>
        /// <param name="playerId">The player id to get the data for.</param>
        /// <returns>The dictionary upon task completion.</returns>
        Task<IDictionary<uint, IItem>> GetItemsForPlayerAsync(uint playerId);

        /// <summary>
        /// Caches the players items, this operation should happen uppon disconnection,
        /// so if reconnecting the players items are cached.
        /// </summary>
        /// <param name="playerId">The player id whose items to cache.</param>
        /// <param name="items">The players items.</param>
        void CacheItems(uint playerId, ICollection<IItem> items);

        /// <summary>
        /// Initializes the inventory for the session.
        /// </summary>
        /// <param name="session">The session to initialize the inventory for.</param>
        /// <param name="items">The items to initialize the inventory with.</param>
        void InitializeInventoryForSession(ISession session, IDictionary<uint, IItem> items);
    }
}
