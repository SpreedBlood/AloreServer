namespace Alore.API.Item.Models
{
    public interface IItemTemplate
    {
        /// <summary>
        /// Gets the id of the item template.
        /// </summary>
        uint Id { get; }

        /// <summary>
        /// Gets the sprite id that the template is matched with from the furnidata xml
        /// </summary>
        int SpriteId { get; }

        /// <summary>
        /// Gets the width of the item template. (x-axis)
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Gets the length of the item template. (y-axis)
        /// </summary>
        int Length { get; }

        /// <summary>
        /// Gets the amount of the interaction modes.
        /// </summary>
        int InteractionModes { get; }

        /// <summary>
        /// Gets the type of the item template (S = floor, W = wall, B = bot)
        /// </summary>
        string Type { get; }

        /// <summary>
        /// Gets the public name of the item template.
        /// </summary>
        string PublicName { get; }

        /// <summary>
        /// Gets the class name of the item name.
        /// </summary>
        string ItemName { get; }
    }
}