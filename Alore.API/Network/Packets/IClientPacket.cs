namespace Alore.API.Network.Packets
{
    public interface IClientPacket
    {
        /// <summary>
        /// Return the header of the incoming client packet.
        /// </summary>
        short Header { get; }

        /// <summary>
        /// Read an integer from the incoming packet. (4 bytes)
        /// </summary>
        /// <returns>The integer read from the packet.</returns>
        int ReadInt();

        /// <summary>
        /// Read a short from the incoming packet. (2 bytes)
        /// </summary>
        /// <returns>The short read from the packet.</returns>
        short ReadShort();

        /// <summary>
        /// Read a byte from the incoming packet.
        /// </summary>
        /// <returns>The byte read from the packet.</returns>
        byte ReadByte();
        
        /// <summary>
        /// Read an array of bytes from the incoming packets.
        /// </summary>
        /// <param name="length"></param>
        /// <returns>The bytes read from the packet.</returns>
        byte[] ReadBytes(int length);

        /// <summary>
        /// Read a byte from the array and then check if it's true or false.
        /// (1 = true, 2 = false).
        /// </summary>
        /// <returns>True or false depending on the byte.</returns>
        bool ReadBool();

        /// <summary>
        /// Read a string from the incoming packet. First read the length(short) of
        /// the string in bytes and then convert the byte array to a readable string.
        /// </summary>
        /// <returns>The string read from the bytes.</returns>
        string ReadString();
    }
}