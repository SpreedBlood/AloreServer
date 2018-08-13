namespace Alore.API.Network.Clients
{
    using System;
    using System.Threading.Tasks;
    using Alore.API.Item.Models;
    using Alore.API.Room.Entities;
    using Alore.API.Room.Models;
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
        /// The current room that the session is located in. If the session isn't
        /// in a room then this is null.
        /// </summary>
        IRoom CurrentRoom { get; set; }

        /// <summary>
        /// The base entity that's associated with the session. If the session isn't
        /// in a room then this is null.
        /// </summary>
        BaseEntity Entity { get; set; }

        /// <summary>
        /// The inventory of the session. This gets initialized when opening the inventory.
        /// </summary>
        IInventory Inventory { get; set; }

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
