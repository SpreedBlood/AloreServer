namespace Alore.Room
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Alore.API.Config;
    using API.Room.Models;
    using API.Sql;
    using Models;

    internal class RoomDao : AloreDao
    {
        public RoomDao(IConfigController configController) : base(configController)
        {
        }

        internal async Task<IRoomData> GetRoomData(int id)
        {
            RoomData roomData = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        roomData = new RoomData(reader);
                    }
                }, "SELECT id, score, name, password, model_name FROM rooms WHERE id = @0 LIMIT 1", id);
            });
            
            return roomData;
        }

        internal async Task<IEnumerable<IRoomModel>> GetRoomModels()
        {
            List<RoomModel> roomModels = new List<RoomModel>();

            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    while (await reader.ReadAsync())
                    {
                        roomModels.Add(new RoomModel(reader));
                    }
                }, "SELECT id, heightmap FROM room_models");
            });

            return roomModels;
        }
    }
}