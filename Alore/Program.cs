using Alore.Helpers;
using Alore.Network.Packets;
using DotNetty.Buffers;
using Microsoft.Extensions.DependencyInjection;

namespace Alore
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using API;
    using API.Sql.Test;
    using Handshake;
    using Landing;
    using Messenger;
    using Navigator;
    using Network;
    using Player;
    using Room;

    public static class Program
    {
        private static Listener _listener;

        public static async Task Main()
        {
            //await TestAloreSql();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging();

            ControllerDiHelper.ConfigureServices(serviceCollection);
            ClientPacketDiHelper.ConfigureServices(serviceCollection);
            
            serviceCollection.AddSingleton<IEventProvider, EventProvider>();

            var sp = serviceCollection.BuildServiceProvider();

            var test = sp.GetService<IEventProvider>();
            var ddd = true;
            /*List<IService> services = new List<IService>
            {
                new PlayerService(),
                new MessengerService(),
                new HandshakeService(),
                new NavigatorService(),
                new LandingService(),
                new RoomService()
            };

            foreach (IService service in services)
            {
                service.Initialize(controllerContext);
            }

            foreach (IService service in services)
            {
                service.AddEvents(eventProvider, controllerContext);
            }

            _listener = new Listener();
            await _listener.Listen(30000, controllerContext, eventProvider);

            while (true)
            {
                if (Console.ReadKey(false).Key == ConsoleKey.Enter)
                {
                    await DisposeAsync();
                }
            }*/
            // ReSharper disable once FunctionNeverReturns
        }

        private static async Task TestAloreSql()
        {
            SqlTest testSql = new SqlTest();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            TestModel testModel = await testSql.TestSql();
            Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            stopWatch.Stop();

            Console.WriteLine("Alore MySQL benchmark done!");
        }

        private static async Task DisposeAsync()
        {
            await _listener.DisposeAsync();

            Console.WriteLine("Finished!");
            Environment.Exit(0);
        }
    }
}