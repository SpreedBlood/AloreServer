﻿namespace Alore.Landing
{
    using API;
    using API.Landing;
    using API.Network;
    using Microsoft.Extensions.DependencyInjection;
    using Packets.Incoming;

    internal class LandingService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILandingController, LandingController>();
            AddPackets(serviceCollection);
        }
        
        private static void AddPackets(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAsyncPacket, LandingLoadWidgetMessageEvent>();
        }
    }
}
