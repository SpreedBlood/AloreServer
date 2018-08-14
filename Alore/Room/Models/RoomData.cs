namespace Alore.Room.Models
{
    using API.Room.Models;
    using API.Sql;
    using System.Data.Common;

    internal class RoomData : IRoomData
    {
        internal RoomData(DbDataReader reader)
        {
            Id = reader.Read<uint>("id");
            Score = reader.Read<int>("score");
            OwnerId = reader.Read<int>("owner");
            Name = reader.Read<string>("name");
            Password = reader.Read<string>("password");
            ModelName = reader.Read<string>("model_name");
        }
        
        public uint Id { get; set; }
        public int Score { get; set; }
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ModelName { get; set; }
    }
}