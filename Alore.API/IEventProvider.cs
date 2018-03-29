namespace Alore.API
{
    using System.Collections.Generic;
    using Network;

    public interface IEventProvider
    {
        Dictionary<short, IAsyncPacket> Events { get; }
    }
}