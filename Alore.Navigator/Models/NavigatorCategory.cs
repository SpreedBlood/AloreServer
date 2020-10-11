namespace Alore.Navigator.Models
{
    using Alore.API.Navigator.Models;
    using Alore.API.Sql;
    using System;
    using System.Data.Common;

    internal class NavigatorCategory : INavigatorCategory
    {
        internal NavigatorCategory(DbDataReader reader)
        {
            Id = reader.Read<uint>("id");
            MinRank = reader.Read<int>("min_rank");
            PublicName = reader.Read<string>("public_name");
            Identifier = reader.Read<string>("identifier");
            Category = reader.Read<string>("category");
            CategoryType = Enum.Parse<CategoryType>(reader.Read<string>("category_type"));
        }
        
        public uint Id { get; set; }
        public int MinRank { get; set; }
        public string PublicName { get; set; }
        public string Identifier { get; set; }
        public string Category { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}
