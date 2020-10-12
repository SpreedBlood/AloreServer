using System;
using System.Threading.Tasks;
using Alore.API.Network;
using Alore.API.Network.Clients;
using Alore.Handshake.Packets.Incoming.Args;
using Microsoft.Extensions.Logging;

namespace Alore.Handshake.Packets.Incoming
{
    public class CheckReleaseMessageEvent : AbstractAsyncPacket<ReleaseArgs>
    {
        public override short Header { get; } = Headers.CheckReleaseEvent;

        private readonly ILogger<CheckReleaseMessageEvent> _logger;

        public CheckReleaseMessageEvent(ILogger<CheckReleaseMessageEvent> logger)
        {
            _logger = logger;
        }

        protected override Task HandleAsync(ISession session, ReleaseArgs args)
        {
            _logger.LogInformation(args.Release);
            return Task.CompletedTask;
        }
    }
}