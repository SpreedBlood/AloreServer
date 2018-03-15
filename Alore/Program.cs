namespace Alore
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using API.Sql.Test;
    using Network;
    using Player;

    class Program
    {
        public static async Task Main()
        {
            new SqlTest().TestSql();

            Console.ReadKey();
            Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> events = new Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>>();

            ControllerContext controllerContext = new ControllerContext();
            new PlayerService(events).Initialize(controllerContext);

            await new Listener().Listen(30000, controllerContext, events);
            Console.ReadKey();
        }
    }
}