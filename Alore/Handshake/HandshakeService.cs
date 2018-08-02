namespace Alore.Handshake
{
    using API;
    using API.Network;
    using Microsoft.Extensions.DependencyInjection;
    using Packets.Incoming;

    /// <summary>
    /// The handshake service initializes the required services.
    /// </summary>
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
