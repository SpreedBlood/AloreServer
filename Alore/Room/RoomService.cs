namespace Alore.Room
{
    using API;
    using API.Room;
    using Microsoft.Extensions.DependencyInjection;

    internal class RoomService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRoomController, RoomController>();
        }
    }
}
