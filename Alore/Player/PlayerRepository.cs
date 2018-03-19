namespace Alore.Player
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public class PlayerRepostiory
    {
        private readonly PlayerDao _playerDao;
        private readonly Dictionary<uint, Player> _players;
        
        public PlayerRepostiory(PlayerDao playerDao)
        {
            _playerDao = playerDao;
            
            _players = new Dictionary<uint, Player>();
        }

        public async Task<Player> GetPlayerById(uint id)
        {
            if (_players.TryGetValue(id, out Player player)) return player;

            player = await _playerDao.GetPlayerByIdAsync(id);
            _players.Add(player.Id, player);
            
            return player;
        }

        public async Task<Player> GetPlayerBySso(string sso) =>
            await _playerDao.GetPlayerBySsoAsync(sso);
    }
}