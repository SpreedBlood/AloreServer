namespace Alore.API.Network
{
    using System.Threading.Tasks;
    using Clients;
    using Packets;

    public interface IAsyncPacket
    {
        /// <summary>
        /// The op-code to figure out which event this is used to handle.
        /// </summary>
        short Header { get; }

        /// <summary>
        /// Handles the incoming packet asynchronously.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="clientPacket">The packet that comes with the message.</param>
        /// <returns>The event handled upon task completion.</returns>
        Task HandleAsync(ISession session, IClientPacket clientPacket);
    }
}