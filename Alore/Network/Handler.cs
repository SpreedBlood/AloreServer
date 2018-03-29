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

    public class Handler : SimpleChannelInboundHandler<ClientPacket>
    {
        private readonly Dictionary<short, IAsyncPacket> _events;
        private readonly Dictionary<IChannelId, ISession> _sessions;

        internal Handler(IEventProvider eventProvider)
        {
            _events = eventProvider.Events;

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
                if (_events.TryGetValue(msg.Header, out IAsyncPacket packet))
                {
                    await packet.HandleAsync(session, msg);
                    Console.WriteLine($"Handled packet: {msg.Header} : {packet.GetType().Name}");
                }
                else
                {
                    Console.WriteLine($"Unkown event: {msg.Header}");
                }
            }
        }
    }
}