namespace Alore.Room
{
    using System.Threading.Tasks;
    using API.Room;
    using API.Room.Models;

    internal class RoomController : IRoomController
    {
        private readonly RoomRepository _roomRepository;

        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public Task<IRoom> GetRoomByIdAsync(int id) =>
            _roomRepository.GetRoomByIdAsync(id);
    }
}
