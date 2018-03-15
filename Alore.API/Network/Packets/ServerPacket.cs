namespace Alore.API.Network.Packets
{
    using System.Text;
    using DotNetty.Buffers;

    public abstract class ServerPacket
    {
        public IByteBuffer ByteBuffer { get; }

        protected ServerPacket(short header)
        {
            ByteBuffer = Unpooled.Buffer(6);
            ByteBuffer.WriteInt(-1);
            ByteBuffer.WriteShort(header);
        }

        public bool HasLength =>
            ByteBuffer.GetInt(0) > -1;

        protected void WriteInt(int i) =>
            ByteBuffer.WriteInt(i);

        protected void WriteShort(short s) =>
            ByteBuffer.WriteShort(s);

        protected void WriteBoolean(bool b) =>
            ByteBuffer.WriteByte(b ? 1 : 0);

        protected void WriteString(string s)
        {
            ByteBuffer.WriteShort(s.Length);
            ByteBuffer.WriteBytes(Encoding.UTF8.GetBytes(s));
        }
    }
}