namespace Alore.API.Network.Clients
{
    using System;
    using System.Threading.Tasks;
    using Packets;
    using Player.Models;

    public interface ISession : IDisposable
    {
        /// <summary>
        /// The playerdata associated with the session.
        /// The player is set after the auth ticket.
        /// </summary>
        IPlayer Player { get; set; }

        /// <summary>
        /// The unique id from where the session is connected.
        /// </summary>
        string UniqueId { get; set; }

        /// <summary>
        /// Write the outgoing packet to the executor and flush the messages.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>Task completion.</returns>
        Task WriteAndFlushAsync(ServerPacket msg);

        /// <summary>
        /// Write the outgoing packet to the executor.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>Task completion.</returns>
        Task WriteAsync(ServerPacket msg);
    }
}
