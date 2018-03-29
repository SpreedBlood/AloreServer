namespace Alore.Room.Models
{
    using API.Room.Models;
    using API.Sql;
    
    internal class Room : AloreModel, IRoom
    {
        [AloreColumn("id")]
        public uint Id { get; set; }
    }
}