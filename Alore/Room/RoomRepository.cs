namespace Alore.Room
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Room.Models;
    using Models;

    internal class RoomRepository
    {
        private readonly RoomDao _roomDao;

        private Dictionary<int, IRoom> _rooms;
        
        internal RoomRepository(RoomDao roomDao)
        {
            _roomDao = roomDao;
            
            _rooms = new Dictionary<int, IRoom>();
        }

        internal async Task<IRoom> GetRoomByIdAsync(int id)
        {
            //There's already a cached version of this room.
            if (_rooms.TryGetValue(id, out IRoom room))
            {
                return room;
            }

            //Initialize the new room & cache it.
            IRoomData roomData = await _roomDao.GetRoomData(id);
            room = new Room(roomData);
            _rooms.Add(id, room);
            return room;
        }
    }
}
