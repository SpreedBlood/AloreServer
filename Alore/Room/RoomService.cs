namespace Alore.Room
{
    using Alore.API.Network;
    using Alore.Room.Packets.Incoming;
    using API;
    using API.Room;
    using Microsoft.Extensions.DependencyInjection;

    internal class RoomService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<RoomDao>();
            serviceCollection.AddSingleton<RoomRepository>();
            serviceCollection.AddSingleton<IRoomController, RoomController>();
            AddPackets(serviceCollection);
        }

        private static void AddPackets(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, OpenFlatConnectionEvent>();
        }
    }
}
