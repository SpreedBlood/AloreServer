namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;
    using Alore.API.Room.Models;

    internal class HeightMapComposer : ServerPacket
    {
        public HeightMapComposer(IRoomModel roomModel)
            : base(Headers.HeightMapMessageComposer)
        {
            string[] map = roomModel.HeightMap.Split("\\{13}");

            WriteInt(roomModel.MapSizeX);
            WriteInt(roomModel.MapSizeX * roomModel.MapSizeY);

            for (int y = 0; y < roomModel.MapSizeY; y++)
            {

                string line = map[y];
                line = line.Replace(char.ToString((char)10), "");
                line = line.Replace(char.ToString((char)13), "");

                foreach (char pos in line)
                {

                    if (pos == 'x')
                    {
                        WriteShort(-1);
                    }
                    else
                    {

                        int height = 0;

                        if (int.TryParse(pos.ToString(), out int parsedHeight))
                        {
                            height = parsedHeight;
                        }
                        else
                        {

                            int intValue = pos;
                            height = (intValue - 87);
                        }

                        WriteShort((short)(height * 256));
                    }
                }
            }
        }
    }
}