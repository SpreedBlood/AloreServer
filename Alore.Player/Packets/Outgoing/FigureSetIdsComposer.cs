namespace Alore.Player.Packets.Outgoing
{
    using Alore.API.Network.Packets;

    public class FigureSetIdsComposer : ServerPacket
    {
        public FigureSetIdsComposer()
            : base(Headers.FigureSetIdsMessageComposer)
        {
            WriteInt(0);

            WriteInt(0);
        }
    }
}
