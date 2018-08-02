namespace Alore.Room.Models
{
    using API.Room.Models;
    using System.Data.Common;

    internal class RoomData : IRoomData
    {
        internal RoomData(DbDataReader reader)
        {
            Id = (uint)reader["id"];
            Name = (string)reader["name"];
            Password = (string)reader["password"];
            ModelName = (string)reader["model_name"];
        }
        
        public uint Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ModelName { get; set; }
    }
}