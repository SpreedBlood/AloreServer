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
            Position = new Position(
                reader.Read<int>("x"),
                reader.Read<int>("y"),
                reader.Read<double>("z"));
        }

        public uint Id { get; }
        public Position Position { get; }
    }
}