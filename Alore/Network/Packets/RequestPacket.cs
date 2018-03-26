namespace Alore.Network.Packets
{
    using System.Text;
    using API.Network.Packets;
    using DotNetty.Buffers;

    public class ClientPacket : IClientPacket
    {
        public short Header { get; }
        private readonly IByteBuffer _buf;

        public ClientPacket(IByteBuffer buffer)
        {
            Header = buffer.ReadShort();
            _buf = buffer;
        }

        public short ReadShort() =>
            _buf.ReadShort();

        public byte ReadByte() =>
            _buf.ReadByte();

        public byte[] ReadBytes(int length) =>
            _buf.ReadBytes(length).Array;

        public bool ReadBool() =>
            _buf.ReadByte() == 1;

        public int ReadInt() =>
            _buf.ReadInt();

        public string ReadString()
        {
            short length = _buf.ReadShort();
            IByteBuffer data = _buf.ReadBytes(length);
            return Encoding.Default.GetString(data.Array);
        }

        public override string ToString() =>
            Encoding.Default.GetString(_buf.Array);
    }
}