namespace Alore.Room.Packets.Outgoing
{
    using Alore.API.Network.Packets;
    using Alore.API.Room.Models;
    using System;

    internal class HeightMapComposer : ServerPacket
    {
        public HeightMapComposer(IRoomModel roomModel)
            : base(Headers.HeightMapMessageComposer)
        {
            WriteInt(roomModel.MapSizeX);
            WriteInt(roomModel.MapSizeX * roomModel.MapSizeY);

            for (int y = 0; y < roomModel.MapSizeY; y++)
            {
                for (int x = 0; x < roomModel.MapSizeX; x++)
                {
                    //Tile is valid.
                    if (roomModel.GetTileState(x, y))
                    {
                        WriteShort((short)(roomModel.GetHeight(x, y) * 256));
                    }
                    else
                    {
                        WriteShort(-1);
                    }
                }
            }
        }
    }
}