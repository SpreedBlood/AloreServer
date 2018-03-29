namespace Alore
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using API;
    using API.Network;
    using API.Sql.Test;
    using Handshake;
    using Landing;
    using Messenger;
    using Navigator;
    using Network;
    using Player;
    using Room;

    class Program
    {
        private static Listener _listener;

        public static async Task Main()
        {
            //await TestAloreSql();

            IEventProvider eventProvider = new EventProvider();
            ControllerContext controllerContext = new ControllerContext();

            List<IService> services = new List<IService>
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
                service.AddEvents(eventProvider);
            }

            _listener = new Listener();
            await _listener.Listen(30000, controllerContext, eventProvider);

            while (true)
            {
                if (Console.ReadKey(false).Key == ConsoleKey.Enter)
                {
                    await DisposeAsync();
                }
            }
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

    internal class EventProvider : IEventProvider
    {
        public Dictionary<short, IAsyncPacket> Events { get; } = new Dictionary<short, IAsyncPacket>();
    }
}