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
        /// The player settings associated with the current session.
        /// The player settings are set after sso ticket.
        /// </summary>
        IPlayerSettings PlayerSettings { get; set; }

        /// <summary>
        /// The player stats associated with the current session.
        /// The lpayer stats are set after the info retrieve.
        /// </summary>
        IPlayerStats PlayerStats { get; set; }

        /// <summary>
        /// The unique id from where the session is connected.
        /// </summary>
        string UniqueId { get; set; }

        /// <summary>
        /// Write the outgoing packet to the executor and flush the messages.
        /// </summary>
        /// <param name="msg">The packet to write.</param>
        /// <returns>Task completion.</returns>
        Task WriteAndFlushAsync(ServerPacket msg);

        /// <summary>
        /// Write the outgoing packet to the executor.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns>Task completion.</returns>
        Task WriteAsync(ServerPacket msg);

        /// <summary>
        /// Flush the packets.
        /// </summary>
        void Flush();
    }
}
