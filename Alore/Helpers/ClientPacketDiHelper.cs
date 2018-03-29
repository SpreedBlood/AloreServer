using Alore.API.Network;
using Alore.Handshake.Packets.Incoming;
using Alore.Landing.Packets.Incoming;
using Alore.Messenger.Packets.Incoming;
using Alore.Navigator.Packets.Incoming;
using Alore.Player.Packets.Incoming;
using Microsoft.Extensions.DependencyInjection;

namespace Alore.Helpers
{
    public static class ClientPacketDiHelper
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            ConfigurePlayerPacketServices(serviceCollection);
            ConfigureHanshakePacketServices(serviceCollection);
            ConfigureLandingPacketServices(serviceCollection);
            ConfigureMessengerPacketServices(serviceCollection);
            ConfigureNavigatorPacketServices(serviceCollection);
        }

        private static void ConfigurePlayerPacketServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, GetCreditsInfoMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, InfoRetrieveMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, ScrGetUserInfoMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, SsoTicketMessageEvent>();
        }

        private static void ConfigureHanshakePacketServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, UniqueIdMessageEvent>();
        }

        private static void ConfigureLandingPacketServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, LandingLoadWidgetMessageEvent>();
        }

        private static void ConfigureMessengerPacketServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, MessengerInitMessageEvent>();
        }

        private static void ConfigureNavigatorPacketServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, GetNavigatorFlatsMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, GetUserFlatCatsMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, InitializeNewNavigatorMessageEvent>();
            serviceCollection.AddSingleton<IAsyncPacket, NavigatorSearchMessageEvent>();
        }
    }
}