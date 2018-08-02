namespace Alore.Navigator.Packets.Outgoing
{
    using Alore.API.Navigator.Models;
    using Alore.API.Network.Packets;
    using System.Collections.Generic;

    public class UserFlatCatsComposer : ServerPacket
    {
        public UserFlatCatsComposer(IList<INavigatorCategory> categories, int playerRank)
            : base(Headers.UserFlatCatsMessageComposer)
        {
            WriteInt(categories.Count);

            foreach (INavigatorCategory category in categories)
            {
                WriteInt(category.Id);
                WriteString(category.PublicName);
                WriteBoolean(category.MinRank <= playerRank);
                WriteBoolean(false);
                WriteString("");
                WriteString("");
                WriteBoolean(false);
            }
        }
    }
}
