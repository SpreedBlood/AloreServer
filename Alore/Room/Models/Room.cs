namespace Alore.Room.Models
{
    using System;
    using API.Room.Models;

    internal class Room : IRoom, IDisposable
    {
        public IRoomData RoomData { get; set; }
        
        internal Room(IRoomData roomData)
        {
            RoomData = roomData;
        }

        public void Dispose()
        {
        }
    }
}