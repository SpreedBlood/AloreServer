namespace Alore.Room
{
    internal class RoomRepository
    {
        private readonly RoomDao _roomDao;

        internal RoomRepository(RoomDao roomDao)
        {
            _roomDao = roomDao;
        }
    }
}
