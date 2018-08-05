namespace Alore.Room.Packets.Incoming
{
    using System.Threading.Tasks;
    using Alore.API.Network;
    using Alore.API.Network.Clients;
    using Alore.API.Network.Packets;
    using Alore.API.Room;
    using Alore.API.Room.Models;
    using Alore.API.Tasks;
    using Alore.Room.Packets.Outgoing;

    internal class OpenFlatConnectionEvent : IAsyncPacket
    {
        private readonly IRoomController _roomController;
        private readonly TaskHandler _taskHandler;

        public OpenFlatConnectionEvent(
            IRoomController roomController,
            TaskHandler taskHandler)
        {
            _roomController = roomController;
            _taskHandler = taskHandler;
        }

        public short Header => 3464;

        public async Task HandleAsync(ISession session, IClientPacket clientPacket)
        {
            int roomId = clientPacket.ReadInt();
            string password = clientPacket.ReadString();

            IRoom room = await _roomController.GetRoomByIdAndPassword(roomId, password);
            if (room != null)
            {
                await session.WriteAndFlushAsync(new OpenConnectionComposer());
                await session.WriteAndFlushAsync(new RoomReadyComposer(room.RoomData.ModelName, room.RoomData.Id));
                await session.WriteAndFlushAsync(new RoomRatingComposer(room.RoomData.Score));

                if (!room.CycleActive)
                {
                    room.SetupRoomCycle(_taskHandler);
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
