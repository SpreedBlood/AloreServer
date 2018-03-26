namespace Alore.Room
{
    using Alore.API;

    internal class RoomService : IService
    {
        public void AddEvents(IEventProvider eventProvider)
        {
        }

        public void Initialize(IControllerContext context)
        {
            context.RoomController = new RoomController(new RoomRepository(new RoomDao()));
        }
    }
}
