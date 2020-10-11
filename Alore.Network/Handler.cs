namespace Alore.Network
{
    using System;
    using System.Collections.Generic;
    using API;
    using API.Network;
    using API.Network.Clients;
    using Clients;
    using DotNetty.Transport.Channels;
    using Packets;

    // TODO: Add interface?
    public class Handler : SimpleChannelInboundHandler<ClientPacket>
    {
        private readonly IEventProvider _eventProvider;
        private readonly Dictionary<IChannelId, ISession> _sessions;

        public Handler(IEventProvider eventProvider)
        {
            _eventProvider = eventProvider;

            _sessions = new Dictionary<IChannelId, ISession>();
        }

        public override void ChannelRegistered(IChannelHandlerContext ctx)
        {
            _sessions.Add(ctx.Channel.Id, new Session(ctx));
        }

        public override void ChannelUnregistered(IChannelHandlerContext ctx)
        {
            _sessions.Remove(ctx.Channel.Id);
        }

        protected override async void ChannelRead0(IChannelHandlerContext ctx, ClientPacket msg)
        {
            if (_sessions.TryGetValue(ctx.Channel.Id, out ISession session))
            {
                await _eventProvider.TriggerEvent(session, msg);
            }
        }
    }
}