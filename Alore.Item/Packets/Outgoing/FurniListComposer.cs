namespace Alore.Item.Packets.Outgoing
{
    using Alore.API.Item.Models;
    using Alore.API.Network.Packets;
    using System.Collections.Generic;

    public class FurniListComposer : ServerPacket
    {
        public FurniListComposer(ICollection<IItem> items)
            : base(Headers.FurniListMessageComposer)
        {
            //TODO: Paging
            WriteInt(1);
            WriteInt(0);

            WriteInt(items.Count);
            foreach (IItem item in items)
            {
                WriteInt(item.ItemData.Id);
                WriteString(item.ItemTemplate.Type.ToUpper());
                WriteInt(item.ItemData.Id);
                WriteInt(item.ItemTemplate.SpriteId);

                WriteInt(1);
                WriteInt(0);
                WriteString(item.ItemData.ExtraData);

                WriteBoolean(false); //Allow ecotron.
                WriteBoolean(true); //Allow trade
                WriteBoolean(true); //Allow inventory stack
                WriteBoolean(true); //Allow the item to be sold on the market place.

                WriteInt(-1);
                WriteBoolean(false);
                WriteInt(-1);

                if (item.ItemTemplate.Type != "i")
                {
                    WriteString("");
                    WriteInt(0);
                }
            }
        }
    }
}
