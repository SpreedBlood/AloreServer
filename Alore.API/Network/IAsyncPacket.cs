namespace Alore.API.Network
{
    using System.Threading.Tasks;
    using Clients;
    using Packets;

    public interface IAsyncPacket
    {
        Task HandleAsync(ISession session, IClientPacket clientPacket);
    }
}