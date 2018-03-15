namespace Alore.Network
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Network;
    using API.Network.Clients;
    using API.Network.Packets;
    using Clients;
    using DotNetty.Transport.Channels;
    using Packets;

    public class Handler : SimpleChannelInboundHandler<ClientPacket>
    {
        private readonly ControllerContext _controllerContext;
        private readonly Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> _events;
        private readonly Dictionary<IChannelId, ISession> _sessions;

        internal Handler(ControllerContext gameContext, Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> events)
        {
            _controllerContext = gameContext;
            _events = events;

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
                if (_events.TryGetValue(msg.Header, out Func<ISession, IClientPacket, IControllerContext, Task> action))
                {
                    await action(session, msg, _controllerContext);
                    Console.WriteLine($"Handled packet: {msg.Header}");
                }
                else
                {
                    Console.WriteLine($"Unkown event: {msg.Header}");
                }
            }
        }
    }
}