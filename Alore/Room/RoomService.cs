namespace Alore.Room
{
    using API;

    internal class RoomService : IService
    {
        public void AddEvents(IEventProvider eventProvider, IControllerContext context)
        {
        }

        public void Initialize(IControllerContext context)
        {
            context.RoomController = new RoomController(new RoomRepository(new RoomDao()));
        }
    }
}
