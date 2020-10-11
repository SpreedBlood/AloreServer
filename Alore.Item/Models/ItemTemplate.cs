namespace Alore.Item.Models
{
    using Alore.API.Item.Models;
    using Alore.API.Sql;
    using System.Data.Common;

    internal class ItemTemplate : IItemTemplate
    {
        internal ItemTemplate(DbDataReader reader)
        {
            Id = reader.Read<uint>("id");
            SpriteId = reader.Read<int>("sprite_id");
            Width = reader.Read<int>("width");
            Length = reader.Read<int>("length");
            InteractionModes = reader.Read<int>("interaction_modes_count");
            Type = reader.Read<string>("type");
            PublicName = reader.Read<string>("public_name");
            ItemName = reader.Read<string>("item_name");
        }

        public uint Id { get; }
        public int SpriteId { get; }
        public int Width { get; }
        public int Length { get; }
        public int InteractionModes { get; }
        public string Type { get; }
        public string PublicName { get; }
        public string ItemName { get; }
    }
}