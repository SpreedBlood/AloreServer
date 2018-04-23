namespace Alore.API.Room
{
    using System.Threading.Tasks;
    using Models;

    public interface IRoomController
    {
        Task<IRoom> GetRoomByIdAsync(int id);
    }
}
