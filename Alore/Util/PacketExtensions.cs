namespace Alore.Util
{
    using Alore.API.Network;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using System.Reflection;

    internal static class PacketExtensions
    {
        internal static void RegisterAllPackets(this IServiceCollection serviceCollection)
        {
            foreach (Type type in Assembly.GetEntryAssembly().GetTypes())
            {
                if (type.GetInterfaces().Contains(typeof(IAsyncPacket)))
                {
                    serviceCollection.AddSingleton(typeof(IAsyncPacket), type);
                }
            }
        }
    }
}
