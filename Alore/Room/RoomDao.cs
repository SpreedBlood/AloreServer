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
                await Select(transaction, reader =>
                {
                    roomData = new RoomData();
                    roomData.SetPropertyValues(reader);
                }, "SELECT id, name FROM rooms WHERE id = @0 LIMIT 1", id);
            });
            
            return roomData;
        }
    }
}