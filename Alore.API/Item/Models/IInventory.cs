namespace Alore.API.Item.Models
{
    public interface IInventory
    {
        /// <summary>
        /// Checks if the cache contains the item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool ContainsItem(uint id);

        /// <summary>
        /// Gets a cached item from the dictionary. There's no checking so can return null.
        /// </summary>
        /// <param name="id">The item id to get.</param>
        /// <returns>The cached item or null.</returns>
        IItem GetItem(uint id);

        /// <summary>
        /// Tries to get the the item from the cache, use this rather than GetItem(uint id).
        /// Use this with an if statement so that u don't have to check if the item is null.
        /// </summary>
        /// <param name="id">The id of the item</param>
        /// <param name="item">The item that will be assigned to if the id exists.</param>
        /// <returns>True if the item exist, or false if not.</returns>
        bool TryGetItem(uint id, out IItem item);
    }
}
