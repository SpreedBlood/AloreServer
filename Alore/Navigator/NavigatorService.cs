namespace Alore.Navigator
{
    using API;
    using API.Navigator;
    using API.Network;
    using Microsoft.Extensions.DependencyInjection;
    using Packets.Incoming;

    internal class NavigatorService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<NavigatorDao>();
            serviceCollection.AddSingleton<NavigatorRepository>();
            serviceCollection.AddSingleton<INavigatorController, NavigatorController>();
            AddPackets(serviceCollection);
        }
        
        private static void AddPackets(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, GetNavigatorFlatsMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, GetUserFlatCatsMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, InitializeNewNavigatorMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, NavigatorSearchMessageEvent>();
        }
    }
}