namespace Alore.Navigator.Models
{
    using Alore.API.Navigator.Models;
    using Alore.API.Sql;

    public class NavigatorCategory : AloreModel, INavigatorCategory
    {
        [AloreColumn("id")]
        public uint Id { get; set; }

        [AloreColumn("min_rank")]
        public int MinRank { get; set; }

        [AloreColumn("public_name")]
        public string PublicName { get; set; }
    }
}
