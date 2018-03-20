using Alore.API.Navigator.Models;
using Alore.API.Network.Packets;
using System.Collections.Generic;

namespace Alore.Navigator.Packets.Outgoing
{
    public class NavigatorFlatCatsComposer : ServerPacket
    {
        public NavigatorFlatCatsComposer(List<INavigatorCategory> categories, int minRank)
            : base(Headers.NavigatorFlatCatsMessageComposer)
        {
            WriteInt(categories.Count);

            foreach (INavigatorCategory category in categories)
            {
                WriteInt(category.Id);
                WriteString(category.PublicName);
                WriteBoolean(category.MinRank <= minRank);
            }
        }
    }
}
