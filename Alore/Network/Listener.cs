namespace Alore.Network
{
    using System.Net;
    using System.Threading.Tasks;
    using API;
    using Codec;
    using DotNetty.Buffers;
    using DotNetty.Transport.Bootstrapping;
    using DotNetty.Transport.Channels;
    using DotNetty.Transport.Channels.Sockets;

    // TODO: Add something as a interface?
    public class Listener
    {
        private IEventLoopGroup _workerGroup;
        private IEventLoopGroup _bossGroup;

        private readonly IEventProvider _eventProvider;

        public Listener(IEventProvider eventProvider)
        {
            _eventProvider = eventProvider;
        }

        public async Task Listen(int port)
        {
            _workerGroup = new MultithreadEventLoopGroup(10);
            _bossGroup = new MultithreadEventLoopGroup(1);

            ServerBootstrap bootstrap = new ServerBootstrap()
                .Group(_bossGroup, _workerGroup)
                .Channel<TcpServerSocketChannel>()
                .ChildHandler(new ActionChannelInitializer<IChannel>(channel =>
                    channel.Pipeline
                        .AddLast("Encoder", new Encoder())
                        .AddLast("Decoder", new Decoder())
                        .AddLast("ClientHandler", new Handler(_eventProvider))
                ))
                .ChildOption(ChannelOption.TcpNodelay, true)
                .ChildOption(ChannelOption.SoKeepalive, true)
                .ChildOption(ChannelOption.SoReuseaddr, true)
                .ChildOption(ChannelOption.SoRcvbuf, 1024)
                .ChildOption(ChannelOption.RcvbufAllocator, new FixedRecvByteBufAllocator(1024))
                .ChildOption(ChannelOption.Allocator, UnpooledByteBufferAllocator.Default);

            IChannel serverChannl = await bootstrap.BindAsync(new IPEndPoint(IPAddress.Parse("0.0.0.0"), port));
            if (serverChannl.Active)
            {
                // TODO: Use injecable logger (see EventProvider).
                Logger<Listener>.Info($"Listening on port: {port}");
            }
            else
            {
                Logger<Listener>.Error($"Failed to listen on port: {port}");
            }
        }

        public async Task DisposeAsync()
        {
            await _workerGroup.ShutdownGracefullyAsync();
            await _bossGroup.ShutdownGracefullyAsync();
        }
    }
}