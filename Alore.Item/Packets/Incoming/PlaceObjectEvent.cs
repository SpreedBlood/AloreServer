namespace Alore.Item.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Item.Models;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Room.Models;
    using Alore.Item.Packets.Outgoing;

    internal class PlaceObjectEvent : IAsyncPacket
    {
        public short Header => 2187;

        public async Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            string rawData = clientPacket.ReadString();
            string[] data = rawData.Split(' ');

            uint itemId = uint.Parse(data[0]);

            IRoom room = session.CurrentRoom;
            if (session.Inventory.Items.TryGetValue(itemId, out IItem item))
            {
                //It's a floor item.
                if (item.ItemTemplate.Type == "s")
                {
                    int x = int.Parse(data[1]);
                    int y = int.Parse(data[2]);
                    uint rot = uint.Parse(data[3]);

                    item.ItemData.Position.X = x;
                    item.ItemData.Position.Y = y;
                    item.ItemData.Rotation = rot;

                    session.Inventory.Items.Remove(itemId);
                    await session.WriteAndFlushAsync(new ObjectAddComposer(item, session.Player.Username));
                }
                else
                {

                }
            }
        }
    }
}
