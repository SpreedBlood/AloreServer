namespace Alore.Navigator.Models
{
    using Alore.API.Navigator.Models;
    using Alore.API.Sql;

    internal class NavigatorCategory : AloreModel, INavigatorCategory
    {
        [AloreColumn("id")]
        public uint Id { get; set; }

        [AloreColumn("min_rank")]
        public int MinRank { get; set; }

        [AloreColumn("public_name")]
        public string PublicName { get; set; }

        [AloreColumn("identifier")]
        public string Identifier { get; set; }

        [AloreColumn("category")]
        public string Category { get; set; }

        [AloreColumn("category_type")]
        public CategoryType CategoryType { get; set; }
    }
}
