namespace Alore.Player.Packets.Outgoing
{
    using Alore.API.Network.Packets;
    using System.Collections.Generic;

    public class FurniListComposer : ServerPacket
    {
        public FurniListComposer(ICollection<int> items)
            : base(Headers.FurniListMessageComposer)
        {
        }
    }
}
