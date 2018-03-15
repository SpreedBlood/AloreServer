namespace Alore.Network.Codec
{
    using System.Collections.Generic;
    using API.Network.Packets;
    using DotNetty.Codecs;
    using DotNetty.Transport.Channels;

    public class Encoder : MessageToMessageEncoder<ServerPacket>
    {
        protected override void Encode(IChannelHandlerContext context, ServerPacket message, List<object> output)
        {
            if (!message.HasLength)
            {
                message.ByteBuffer.SetInt(0, message.ByteBuffer.WriterIndex - 4);
            }

            output.Add(message.ByteBuffer);
        }
    }
}
