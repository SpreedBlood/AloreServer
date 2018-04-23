namespace Alore.Player
{
    using API;
    using API.Network;
    using API.Player;
    using Microsoft.Extensions.DependencyInjection;
    using Packets.Incoming;

    internal class PlayerService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPlayerController, PlayerController>();
            AddPackets(serviceCollection);
        }

        private static void AddPackets(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, GetCreditsInfoMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, InfoRetrieveMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, ScrGetUserInfoMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, SsoTicketMessageEvent>();
        }
    }
}
