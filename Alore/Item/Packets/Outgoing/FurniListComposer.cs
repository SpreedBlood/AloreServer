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
                WriteInt(item.ItemData.Id); //Item id
                WriteString("s"); //Item type S, I, B etc.
                WriteInt(item.ItemData.Id); //Item id
                WriteInt(1619); //Sprite id

                WriteInt(1);
                WriteInt(0);
                WriteString(""); //Extradata

                WriteBoolean(false); //Allow ecotron.
                WriteBoolean(true); //Allow trade
                WriteBoolean(true); //Allow inventory stack
                WriteBoolean(true); //Allow the item to be sold on the market place.

                WriteInt(-1);
                WriteBoolean(false);
                WriteInt(-1);

                WriteString("");
                WriteInt(0);
            }
        }
    }
}
