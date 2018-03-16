namespace Alore
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
            //new SqlTest().TestSql();

            IEventProvider eventProvider = new EventProvider();
            ControllerContext controllerContext = new ControllerContext();

            List<IService> services = new List<IService>(2)
            {
                new PlayerService(),
                new MessengerService(),
                new HandshakeService()
            };

            foreach (IService service in services)
            {
                service.Initialize(controllerContext);
                service.AddEvents(eventProvider);
            }

            await new Listener().Listen(30000, controllerContext, eventProvider);
            Console.ReadKey();
        }
    }

    internal class EventProvider : IEventProvider
    {
        public Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> Events { get; } = new Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>>();
    }
}