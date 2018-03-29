namespace Alore.Room
{
    using API.Room;

    internal class RoomController : IRoomController
    {
        private readonly RoomRepository _roomRepository;

        internal RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
    }
}
