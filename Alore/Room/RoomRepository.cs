namespace Alore.Room
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Room.Models;
    using Models;

    internal class RoomRepository
    {
        private readonly RoomDao _roomDao;
        
        private readonly IDictionary<int, IRoom> _rooms;
        private readonly IDictionary<string, IRoomModel> _roomModels;

        public RoomRepository(RoomDao roomDao)
        {
            _roomDao = roomDao;
            
            _rooms = new Dictionary<int, IRoom>();
            _roomModels = new Dictionary<string, IRoomModel>();
            LoadRoomModels();
        }

        private async void LoadRoomModels()
        {
            IEnumerable<IRoomModel> roomModels = await _roomDao.GetRoomModels();
            foreach (IRoomModel roomModel in roomModels)
            {
                _roomModels.Add(roomModel.Id, roomModel);
            }
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
            if (roomData != null)
            {
                if (_roomModels.TryGetValue(roomData.ModelName, out IRoomModel model))
                {
                    //TODO: Error if the room model doesn't exist.
                    room = new Room(roomData, model);
                    _rooms.Add(id, room);
                    return room;
                }
            }

            return null;
        }
    }
}