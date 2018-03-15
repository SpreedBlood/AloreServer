namespace Alore.Player
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PlayerRepostiory
    {
        private readonly PlayerContext _playerContext;

        public PlayerRepostiory(PlayerContext playerContext)
        {
            _playerContext = playerContext;
        }

        public async Task<Player> GetPlayerById(int id) =>
            await _playerContext.Set<Player>().FindAsync(id);

        public async Task<Player> GetPlayerBySso(string sso) =>
            await _playerContext.Set<Player>().FirstAsync(p => p.SsoTicket == sso);
    }
}