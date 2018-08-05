namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;
    using Alore.API.Room.Entities;
    using System.Collections.Generic;

    public class EntitiesComposer : ServerPacket
    {
        public EntitiesComposer(ICollection<BaseEntity> entities)
            : base(Headers.EntitiesMessageComposer)
        {
            WriteInt(entities.Count);
            foreach (BaseEntity entity in entities)
            {
                entity.Compose(this);
            }
        }

        public EntitiesComposer(BaseEntity entity)
            : base(Headers.EntitiesMessageComposer)
        {
            WriteInt(1);
            entity.Compose(this);
        }
    }
}
