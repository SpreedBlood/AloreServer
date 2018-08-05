namespace Alore
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using Handshake;
    using Landing;
    using Messenger;
    using Navigator;
    using Network;
    using Player;
    using Room;
    using Alore.Util;
    using Alore.Config;

    public class Program
    {
        private Listener _listener;

        private async Task Run()
        {
            List<IService> services = new List<IService>
            {
                new HandshakeService(),
                new LandingService(),
                new MessengerService(),
                new NavigatorService(),
                new PlayerService(),
                new RoomService(),
                new ConfigService()
            };

            // TODO: construct the Program class instead of having things staticly.
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddConsole());

            foreach (IService service in services)
            {
                service.ConfigureServices(serviceCollection);
            }

            //Loops over all the types and registers all the packets!
            serviceCollection.RegisterAllPackets();

            //Sets up the services that the api offers.
            serviceCollection.SetupAPI();

            serviceCollection.AddSingleton<IEventProvider, EventProvider>();

            serviceCollection.AddSingleton<Listener>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            _listener = serviceProvider.GetService<Listener>();

            await _listener.Listen(30000);

            while (true)
            {
                if (Console.ReadKey(false).Key == ConsoleKey.Enter)
                {
                    await DisposeAsync();
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }
        
        private async Task DisposeAsync()
        {
            await _listener.DisposeAsync();

            Environment.Exit(0);
        }

        public static async Task Main()
        {
            await new Program().Run();
            
            //await TestAloreSql();
            // ReSharper disable once FunctionNeverReturns
        }

        /*
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
        }*/
    }
}