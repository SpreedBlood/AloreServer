namespace Alore.Handshake
{
    using API;
    using API.Network;
    using Microsoft.Extensions.DependencyInjection;
    using Packets.Incoming;

    internal class HandshakeService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            AddPackets(serviceCollection);
        }

        private static void AddPackets(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, UniqueIdMessageEvent>();
        }
    }
}
