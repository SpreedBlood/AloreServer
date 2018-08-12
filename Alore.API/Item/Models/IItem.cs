namespace Alore.API.Item.Models
{
    public interface IItem
    {
        /// <summary>
        /// Gets the model of the item containing data from the database.
        /// </summary>
        IItemData ItemData { get; }
    }
}
