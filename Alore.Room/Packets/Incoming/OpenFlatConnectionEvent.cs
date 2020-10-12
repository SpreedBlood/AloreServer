using Alore.Room.Packets.Incoming.Args;

namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Room;
    using Alore.API.Room.Models;
    using Alore.Room.Packets.Outgoing;

    internal class OpenFlatConnectionEvent : AbstractAsyncPacket<FlatConnectionArgs>
    {
        private readonly IRoomController _roomController;

        public OpenFlatConnectionEvent(IRoomController roomController)
        {
            _roomController = roomController;
        }

        public override short Header => 3464;

        protected override async Task HandleAsync(ISession session, FlatConnectionArgs args)
        {
            IRoom room = await _roomController.GetRoomByIdAndPassword(args.RoomId, args.Password);
            if (room != null)
            {
                await session.WriteAndFlushAsync(new OpenConnectionComposer());
                await session.WriteAndFlushAsync(new RoomReadyComposer(room.RoomData.ModelName, room.RoomData.Id));
                await session.WriteAndFlushAsync(new RoomRatingComposer(room.RoomData.Score));

                if (!room.CycleActive)
                {
                    room.SetupRoomCycle();
                }

                session.CurrentRoom = room;
            }
            else
            {
                await session.WriteAndFlushAsync(new CloseConnectionComposer());
            }
        }
    }
}