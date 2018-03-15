namespace Alore.Handshake
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using Packets.Incoming;

    public class HandshakeService : AbstractService
    {
        public HandshakeService(Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> events) : base(events)
        {
        }

        public override void Initialize(IControllerContext context)
        {
            Events.Add(3465, UniqueIdMessageEvent.Execute);
        }
    }
}
