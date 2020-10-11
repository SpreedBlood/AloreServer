using Alore.API.Network.Packets;

namespace Alore.Messenger.Packets.Outgoing
{
    public class MessengerInitComposer : ServerPacket
    {
        public MessengerInitComposer()
            : base(Headers.MessengerInitMessageComposer)
        {
            WriteInt(10);
            WriteInt(300);
            WriteInt(800);

            WriteInt(0);
        }
    }
}