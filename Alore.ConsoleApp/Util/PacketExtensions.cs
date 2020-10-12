namespace Alore.ConsoleApp.Util
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
            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly assembly in assemblies)
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetInterfaces().Contains(typeof(IAsyncPacket)) && !type.IsAbstract)
                {
                    serviceCollection.AddSingleton(typeof(IAsyncPacket), type);
                }
            }
        }
    }
}