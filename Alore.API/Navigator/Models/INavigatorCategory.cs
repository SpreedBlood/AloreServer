namespace Alore.API.Navigator.Models
{
    public interface INavigatorCategory
    {
        /// <summary>
        /// Get the id for the navigator category.
        /// </summary>
        uint Id { get; set; }

        /// <summary>
        /// The minimum required rank to view the category.
        /// </summary>
        int MinRank { get; set; }

        /// <summary>
        /// The public name for the navigator category.
        /// </summary>
        string PublicName { get; set; }
    }
}