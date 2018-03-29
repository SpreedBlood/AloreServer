﻿namespace Alore.Messenger
{
    using Packets.Incoming;
    using API;

    internal class MessengerService : IService
    {
        public void Initialize(IControllerContext context)
        {
        }

        public void AddEvents(IEventProvider eventProvider, IControllerContext context)
        {
            eventProvider.Events.Add(1405, new MessengerInitMessageEvent());
        }
    }
}
