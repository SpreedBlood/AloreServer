namespace Alore.Room.Models
{
    using System;
    using API.Room.Models;

    internal class Room : IRoom, IDisposable
    {
        public IRoomData RoomData { get; set; }
        
        public IRoomModel RoomModel { get; set; }

        internal Room(IRoomData roomData, IRoomModel model)
        {
            RoomData = roomData;
            RoomModel = model;
        }

        public void Dispose()
        {
        }
    }
}