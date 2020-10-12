using Alore.Room.Packets.Incoming.Args;

namespace Alore.Room.Packets.Incoming
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using API.Network;
    using API.Network.Clients;
    using Alore.API.Room.Grid;
    using Alore.API.Room.Grid.Pathfinding;

    public class MoveAvatarEvent : AbstractAsyncPacket<MoveAvatarArgs>
    {
        public override short Header => 3155;

        protected override Task HandleAsync(ISession session, MoveAvatarArgs args)
        {
            IList<Position> walkingPath = PathFinder.FindPath(
                session.CurrentRoom.RoomGrid,
                session.Entity.Position, new Position(args.X, args.Y, 0));
            walkingPath.RemoveAt(walkingPath.Count - 1);
            session.Entity.PathToWalk = walkingPath;
            return Task.CompletedTask;
        }
    }
}