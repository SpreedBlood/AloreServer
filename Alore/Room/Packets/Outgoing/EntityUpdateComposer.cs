namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;
    using Alore.API.Room.Entities;
    using System.Collections.Generic;
    using System.Text;

    public class EntityUpdateComposer : ServerPacket
    {
        public EntityUpdateComposer(ICollection<BaseEntity> entities)
            : base(Headers.EntityUpdateMessageComposer)
        {
            WriteInt(entities.Count);
            foreach (BaseEntity entity in entities)
            {
                WriteInt(entity.Id);
                WriteInt(entity.Position.X);
                WriteInt(entity.Position.Y);
                WriteString(entity.Position.Z.ToString("0.00"));
                WriteInt(entity.BodyRotation); //TODO: Head rotation when talking.
                WriteInt(entity.BodyRotation);

                StringBuilder statuses = new StringBuilder();
                statuses.Append("/");

                foreach (KeyValuePair<string, string> activeStatus in entity.ActiveStatuses)
                {
                    statuses.Append(activeStatus.Key);

                    if (!string.IsNullOrEmpty(activeStatus.Value))
                    {
                        statuses.Append(" ");
                        statuses.Append(activeStatus.Value);
                    }

                    statuses.Append("/");
                }

                statuses.Append("/");
                WriteString(statuses.ToString());
            }
        }
    }
}
