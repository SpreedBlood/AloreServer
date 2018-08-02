namespace Alore.Room
{
    using System.Threading.Tasks;
    using API.Room.Models;
    using API.Sql;
    using Models;

    internal class RoomDao : AloreDao
    {
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
    }
}