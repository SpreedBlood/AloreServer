namespace Alore.API
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Network.Clients;
    using Network.Packets;

    public abstract class AbstractService
    {
        protected Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> Events { get; }

        protected AbstractService(Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> events)
        {
            Events = events;
        }

        public abstract void Initialize(IControllerContext context);
    }
}