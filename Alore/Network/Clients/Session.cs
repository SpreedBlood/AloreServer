namespace Alore.Network.Clients
{
    using System.Threading.Tasks;
    using Alore.API.Room.Models;
    using API.Network.Clients;
    using API.Network.Packets;
    using API.Player.Models;
    using DotNetty.Transport.Channels;

    public class Session : ISession
    {
        private readonly IChannelHandlerContext _ctx;

        public Session(IChannelHandlerContext ctx)
        {
            _ctx = ctx;
        }

        public IPlayer Player { get; set; }

        public IPlayerSettings PlayerSettings { get; set; }

        public IPlayerStats PlayerStats { get; set; }

        public IRoom CurrentRoom { get; set; }

        public string UniqueId { get; set; }

        public async void Dispose()
        {
            await _ctx.CloseAsync();
        }

        public async Task WriteAndFlushAsync(ServerPacket serverPacket) => await _ctx.WriteAndFlushAsync(serverPacket);

        public async Task WriteAsync(ServerPacket serverPacket) => await _ctx.WriteAsync(serverPacket);

        public void Flush() => _ctx.Flush();
    }
}
