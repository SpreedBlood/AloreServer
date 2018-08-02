namespace Alore.Navigator.Packets.Outgoing
{
    using Alore.API.Navigator.Models;
    using Alore.API.Network.Packets;
    using System.Collections.Generic;

    public class NavigatorSearchResultSetComposer : ServerPacket
    {
        public NavigatorSearchResultSetComposer(string category, string data, IList<INavigatorCategory> categories)
            : base(Headers.NavigatorSearchResultSetMessageComposer)
        {
            WriteString(category);
            WriteString(data);

            WriteInt(categories.Count);
            foreach (INavigatorCategory navigatorCategory in categories)
            {
                WriteString(navigatorCategory.Identifier);
                WriteString(navigatorCategory.PublicName);

                WriteInt(1);
                WriteBoolean(false);

                WriteInt(0); //TODO: Thumbnail option.

                //TODO: Make rooms...
                WriteInt(0);
            }
        }
    }
}
