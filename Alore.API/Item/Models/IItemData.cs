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
        /// Gets the sprite id of which this item is associated with. This is used to get the
        /// template of the item.
        /// </summary>
        uint SpriteId { get; }

        /// <summary>
        /// Gets the id of the owner who's the item belongs to.
        /// </summary>
        uint PlayerId { get; }

        /// <summary>
        /// Gets or sets the rotation of the furniture.
        /// </summary>
        uint Rotation { get; set; }

        /// <summary>
        /// Gets the extradata of the item & can set it aswell.
        /// </summary>
        string ExtraData { get; set; }

        /// <summary>
        /// Gets the position of the item (x, y ,z).
        /// </summary>
        Position Position { get; }
    }
}
