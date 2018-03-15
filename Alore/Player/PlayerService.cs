namespace Alore.Player
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API;
    using API.Network.Clients;
    using API.Network.Packets;
    using Packets.Incoming;

    public class PlayerService : AbstractService
    {
        public PlayerService(Dictionary<short, Func<ISession, IClientPacket, IControllerContext, Task>> events)
            : base(events)
        {
        }

        public override void Initialize(IControllerContext context)
        {
            context.PlayerController = new PlayerController(new PlayerRepostiory(new PlayerContext()));
            Events.Add(1930, SsoTicketMessageEvent.Execute);
            Events.Add(3092, InfoRetrieveMessageEvent.Execute);
            Events.Add(2109, GetCreditsInfoMessageEvent.Execute);
            Events.Add(3796, ScrGetUserInfoMessageEvent.Execute);
        }
    }
}
