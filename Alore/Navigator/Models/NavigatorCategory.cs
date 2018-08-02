namespace Alore.Navigator.Models
{
    using Alore.API.Navigator.Models;
    using System;
    using System.Data.Common;

    internal class NavigatorCategory : INavigatorCategory
    {
        internal NavigatorCategory(DbDataReader reader)
        {
            Id = (uint)reader["id"];
            MinRank = (int)reader["min_rank"];
            PublicName = (string)reader["public_name"];
            Identifier = (string)reader["identifier"];
            Category = (string)reader["category"];
            CategoryType = Enum.Parse<CategoryType>((string)reader["category_type"]);
        }
        
        public uint Id { get; set; }
        public int MinRank { get; set; }
        public string PublicName { get; set; }
        public string Identifier { get; set; }
        public string Category { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
