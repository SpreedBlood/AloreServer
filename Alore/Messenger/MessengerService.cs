namespace Alore.Messenger
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;

    public class MessengerService : AbstractService
    {
        public MessengerService(Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> events) : base(events)
        {
        }

        public override void Initialize(IControllerContext context)
        {
        }
    }
}
