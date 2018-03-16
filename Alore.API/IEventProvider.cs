namespace Alore.API
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Network.Clients;
    using Network.Packets;

    public interface IEventProvider
    {
        Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> Events { get; }
    }
}
