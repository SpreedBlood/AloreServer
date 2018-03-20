namespace Alore.Landing.Packets.Outgoing
{
    using Alore.API.Landing.Models;
    using Alore.API.Network.Packets;
    using System.Collections.Generic;

    public class HallOfFameComposer : ServerPacket
    {
        public HallOfFameComposer(List<IHallOfFamer> hallOfFamers, string key)
            : base(Headers.HallOfFameMessageComposer)
        {
            WriteString(key);

            WriteInt(hallOfFamers.Count);
            foreach (IHallOfFamer hallOfFamer in hallOfFamers)
            {
                WriteInt(hallOfFamer.Id);
                WriteString(hallOfFamer.Username);
                WriteString(hallOfFamer.Figure);
                WriteInt(hallOfFamer.Rank);
                WriteInt(hallOfFamer.Id);
            }
        }
    }
}
