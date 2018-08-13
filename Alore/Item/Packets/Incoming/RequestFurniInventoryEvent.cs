namespace Alore.Player.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Alore.API.Item;
    using Alore.API.Item.Models;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.Item.Packets.Outgoing;

    internal class RequestFurniInventoryEvent : IAsyncPacket
    {
        private readonly IItemController _itemController;

        public RequestFurniInventoryEvent(IItemController itemController)
        {
            _itemController = itemController;
        }

        public short Header => 2835;

        public async Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            IDictionary<uint, IItem> items = await _itemController.GetItemsForPlayerAsync(session.Player.Id);
            //Initializes the inventory 
            if (session.Inventory == null)
            {
                _itemController.InitializeInventoryForSession(session, items);
            }

            await session.WriteAndFlushAsync(new FurniListComposer(items.Values));
        }
    }
}
