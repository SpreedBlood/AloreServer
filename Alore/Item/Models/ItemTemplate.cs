namespace Alore.Item.Models
{
    using Alore.API.Sql;
    using System.Data.Common;

    internal class ItemTemplate
    {
        internal ItemTemplate(DbDataReader reader)
        {
            Id = reader.Read<uint>("id");
            SpriteId = reader.Read<int>("sprite_id");
            Type = reader.Read<string>("type");
        }

        public uint Id { get; }
        public int SpriteId { get; }
        public string Type { get; }
    }
}
