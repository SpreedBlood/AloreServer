using Alore.API.Network.Packets;
using Alore.API.Room.Grid;
using System.Collections.Generic;

namespace Alore.API.Room.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity(int id, int x, int y, int rotation, string name, string figure)
        {
            Id = id;
            BodyRotation = rotation;
            Position = new Position(x, y, 0);
            Name = name;
            Figure = figure;

            ActiveStatuses = new Dictionary<string, string>();
        }

        /// <summary>
        /// The generated virtual id of the entity. (Gets generated upon room entry)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The rotation of the entities body.
        /// </summary>
        public int BodyRotation { get; set; }

        /// <summary>
        /// The position of the entity.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the figure of the entity.
        /// </summary>
        public string Figure { get; set; }

        public IDictionary<string, string> ActiveStatuses { get; set; }

        public abstract void Compose(ServerPacket serverPacket);
    }
}
