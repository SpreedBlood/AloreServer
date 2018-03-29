namespace Alore.Room
{
    using API.Room;

    internal class RoomController : IRoomController
    {
        private readonly RoomRepository _roomRepository;

        public RoomController()
        {
            _roomRepository = new RoomRepository(new RoomDao());
        }
    }
}
