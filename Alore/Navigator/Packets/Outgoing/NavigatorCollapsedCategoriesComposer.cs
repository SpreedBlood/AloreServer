namespace Alore.Navigator.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class NavigatorCollapsedCategoriesComposer : ServerPacket
    {
        public NavigatorCollapsedCategoriesComposer()
            : base(Headers.NavigatorCollapsedCategoriesMessageComposer)
        {
            WriteInt(0);
        }
    }
}
