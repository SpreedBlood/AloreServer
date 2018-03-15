namespace Alore.Network.Codec
{
    using System.Collections.Generic;
    using System.Text;
    using DotNetty.Buffers;
    using DotNetty.Codecs;
    using DotNetty.Transport.Channels;
    using Packets;

    public class Decoder : ByteToMessageDecoder
    {
        protected override void Decode(IChannelHandlerContext context, IByteBuffer input, List<object> output)
        {
            input.MarkReaderIndex();

            if (input.ReadableBytes < 6) return;

            byte delimeter = input.ReadByte();
            input.ResetReaderIndex();

            if (delimeter == 60)
            {
                string policy = "<?xml version=\"1.0\"?>\r\n"
                                + "<!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">\r\n"
                                + "<cross-domain-policy>\r\n"
                                + "<allow-access-from domain=\"*\" to-ports=\"*\" />\r\n"
                                + "</cross-domain-policy>\0)";
                context.WriteAndFlushAsync(Unpooled.CopiedBuffer(Encoding.Default.GetBytes(policy)));
            }
            else
            {
                input.MarkReaderIndex();
                int length = input.ReadInt();
                if (input.ReadableBytes < length)
                {
                    input.ResetReaderIndex();
                    return;
                }
                IByteBuffer newBuf = input.ReadBytes(length);

                if (length < 0) return;

                output.Add(new ClientPacket(newBuf));
            }
        }
    }
}