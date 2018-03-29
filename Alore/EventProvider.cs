using System;
using System.Collections.Generic;
using System.Linq;
using Alore.API;
using Alore.API.Network;
using Alore.API.Network.Clients;
using Alore.API.Network.Packets;
using Microsoft.Extensions.Logging;

namespace Alore
{
    public class EventProvider : IEventProvider
    {
        private readonly ILogger<EventProvider> _logger;

        private readonly Dictionary<short, IAsyncPacket> _events;

        public EventProvider(ILogger<EventProvider> logger, IEnumerable<IAsyncPacket> events)
        {
            _logger = logger;
            _events = events.ToDictionary(x => x.Header, x => x);
        }

        public void TriggerEvent(ISession session, IClientPacket clientPacket)
        {
            if (_events.TryGetValue(clientPacket.Header, out var eventHandler))
            {
                _logger.LogDebug($"Executing {eventHandler.GetType().Name} for header: {clientPacket.Header}.");
                eventHandler.HandleAsync(session, clientPacket);
            }
            else
            {
                _logger.LogWarning($"Unable to handle packet: {clientPacket.Header}.");
            }
        }
    }
}