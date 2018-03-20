namespace Alore
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Alore.Landing;
    using Alore.Navigator;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using API.Sql.Test;
    using Handshake;
    using Messenger;
    using Network;
    using Player;

    class Program
    {
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
                new LandingService()
            };

            foreach (IService service in services)
            {
                service.Initialize(controllerContext);
                service.AddEvents(eventProvider);
            }

            await new Listener().Listen(30000, controllerContext, eventProvider);
            Console.ReadKey();
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
    }

    internal class EventProvider : IEventProvider
    {
        public Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> Events { get; } = new Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>>();
    }
}