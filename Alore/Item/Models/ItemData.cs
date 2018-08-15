namespace Alore.Item.Models
{
    using Alore.API.Item.Models;
    using Alore.API.Room.Grid;
    using Alore.API.Sql;
    using System.Data.Common;

    internal class ItemData : IItemData
    {
        internal ItemData(DbDataReader reader)
        {
            Id = reader.Read<uint>("id");
            SpriteId = reader.Read<uint>("sprite_id");
            PlayerId = reader.Read<uint>("player_id");
            Rotation = reader.Read<uint>("rot");
            ExtraData = reader.Read<string>("extradata");
            Position = new Position(
                reader.Read<int>("x"),
                reader.Read<int>("y"),
                reader.Read<double>("z"));
        }

        public uint Id { get; }
        public uint SpriteId { get; }
        public uint PlayerId { get; }
        public uint Rotation { get; set; }
        public string ExtraData { get; set; }
        public Position Position { get; }
    }
}