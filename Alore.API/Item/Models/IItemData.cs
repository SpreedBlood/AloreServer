namespace Alore.API.Item.Models
{
    using Alore.API.Room.Grid;

    public interface IItemData
    {
        /// <summary>
        /// Gets the id of the item.
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// Gets the position of the item (x, y ,z).
        /// </summary>
        Position Position { get; }
    }
}
