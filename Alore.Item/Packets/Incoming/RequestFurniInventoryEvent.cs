namespace Alore.Player.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Alore.API.Item;
    using Alore.API.Item.Models;
    using API.Network;
    using API.Network.Clients;
    using Alore.Item.Packets.Outgoing;

    internal class RequestFurniInventoryEvent : AbstractAsyncPacket
    {
        private readonly IItemController _itemController;

        public RequestFurniInventoryEvent(IItemController itemController)
        {
            _itemController = itemController;
        }

        public override short Header => 2835;

        protected override async Task HandleAsync(ISession session)
        {
            IDictionary<uint, IItem> items;
            //Initializes the inventory 
            if (session.Inventory == null)
            {
                items = await _itemController.GetItemsForPlayerAsync(session.Player.Id);
                _itemController.InitializeInventoryForSession(session, items);
            }

            items = session.Inventory.Items;

            await session.WriteAndFlushAsync(new FurniListComposer(items.Values));
        }
    }
}