namespace Alore.Handshake
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using Packets.Incoming;

    public class HandshakeService : IService
    {
        public void Initialize(IControllerContext context)
        {
        }

        public void AddEvents(IEventProvider eventProvider)
        {
            eventProvider.Events.Add(3465, UniqueIdMessageEvent.Execute);
        }
    }
}
