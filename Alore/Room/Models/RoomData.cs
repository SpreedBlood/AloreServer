namespace Alore.Room.Models
{
    using API.Room.Models;
    using API.Sql;
    
    internal class RoomData : AloreModel, IRoomData
    {
        [AloreColumn("id")]
        public uint Id { get; set; }
        
        [AloreColumn("name")]
        public string Name { get; set; }
    }
}