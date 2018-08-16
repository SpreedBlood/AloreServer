namespace Alore.Room.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Room.Grid;
    using Alore.API.Room.Grid.Pathfinding;

    public class MoveAvatarEvent : IAsyncPacket
    {
        public short Header => 3155;

        public Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            int x = clientPacket.ReadInt();
            int y = clientPacket.ReadInt();
            IList<Position> walkingPath = PathFinder.FindPath(
                session.CurrentRoom.RoomGrid,
                session.Entity.Position, new Position(x, y, 0));
            walkingPath.RemoveAt(walkingPath.Count - 1);
            session.Entity.PathToWalk = walkingPath;
            return Task.CompletedTask;
        }
    }
}
