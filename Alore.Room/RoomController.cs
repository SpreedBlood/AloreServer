namespace Alore.Room
{
    using System.Threading.Tasks;
    using Alore.API.Network.Clients;
    using Alore.API.Room.Entities;
    using Alore.Room.Models.Entities;
    using API.Room;
    using API.Room.Models;

    internal class RoomController : IRoomController
    {
        private readonly RoomRepository _roomRepository;

        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public BaseEntity AddUserToRoom(IRoom room, ISession session)
        {
            IRoomModel roomModel = room.RoomModel;
            UserEntity userEntity = new UserEntity(room.Entities.Count + 1, roomModel.DoorX, roomModel.DoorY, roomModel.DoorDir, session);
            room.AddEntity(userEntity);
            session.Entity = userEntity;

            return userEntity;
        }

        public Task<IRoom> GetRoomByIdAsync(int id) =>
            _roomRepository.GetRoomByIdAsync(id);

        public async Task<IRoom> GetRoomByIdAndPassword(int id, string password)
        {
            IRoom room = await GetRoomByIdAsync(id);
            if (room != null)
            {
                if (room.RoomData.Password == password)
                {
                    return room;
                }
            }

            return null;
        }
    }
}
