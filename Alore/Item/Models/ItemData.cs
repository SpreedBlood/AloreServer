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
            Id = reader.ReadUint("id");
            Position = new Position(reader.ReadInt("x"), reader.ReadInt("y"), reader.ReadDouble("z"));
        }

        public uint Id { get; }
        public Position Position { get; }
    }
}