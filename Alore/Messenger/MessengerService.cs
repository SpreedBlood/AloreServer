namespace Alore.Messenger
{
    using API;
    using API.Messenger;
    using API.Network;
    using Microsoft.Extensions.DependencyInjection;
    using Packets.Incoming;

    internal class MessengerService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMessengerController, MessengerController>();
            AddPackets(serviceCollection);
        }
        
        private static void AddPackets(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, MessengerInitMessageEvent>();
        }
    }
}