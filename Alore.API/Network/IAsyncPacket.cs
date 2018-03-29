namespace Alore.API.Network
{
    using System.Threading.Tasks;
    using Clients;
    using Packets;

    public interface IAsyncPacket
    {
        short Header { get; }

        Task HandleAsync(ISession session, IClientPacket clientPacket);
    }
}