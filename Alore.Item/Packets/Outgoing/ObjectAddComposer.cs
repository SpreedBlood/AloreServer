namespace Alore.Item.Packets.Outgoing
{
    using Alore.API.Item.Models;
    using Alore.API.Network.Packets;
    using System;

    public class ObjectAddComposer : ServerPacket
    {
        public ObjectAddComposer(IItem item, string username)
            : base(Headers.ObjectAddMessageComposer)
        {
            WriteInt(item.ItemData.Id);
            WriteInt(item.ItemTemplate.SpriteId);
            WriteInt(item.ItemData.Position.X);
            WriteInt(item.ItemData.Position.Y);
            WriteInt(item.ItemData.Rotation);
            WriteString(String.Format("{0:0.00}", item.ItemData.Position.Z.ToString()));
            WriteString("");

            WriteInt(1);
            WriteInt(0);
            WriteString(item.ItemData.ExtraData);

            WriteInt(-1);
            WriteInt(item.ItemTemplate.InteractionModes > 0 ? 1 : 0);
            WriteInt(item.ItemData.PlayerId);
            WriteString(username);
        }
    }
}