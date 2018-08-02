namespace Alore.Player
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    internal class PlayerRepostiory
    {
        private readonly PlayerDao _playerDao;
        private readonly Dictionary<uint, Player> _players;

        public PlayerRepostiory(PlayerDao playerDao)
        {
            _playerDao = playerDao;

            _players = new Dictionary<uint, Player>();
        }

        internal async Task<Player> GetPlayerById(uint id)
        {
            if (_players.TryGetValue(id, out Player player)) return player;

            player = await _playerDao.GetPlayerById(id);
            _players.Add(player.Id, player);

            return player;
        }

        internal async Task<Player> GetPlayerBySso(string sso) =>
            await _playerDao.GetPlayerBySso(sso);

        internal async Task<PlayerSettings> GetPlayerSettingsById(uint id) =>
            await _playerDao.GetPlayerSettingsById(id);

        internal async Task CreatePlayerSettings(uint id) =>
            await _playerDao.CreatePlayerSettings(id);

        internal async Task<PlayerStats> GetPlayerStatsById(uint id) =>
             await _playerDao.GetPlayerStatsById(id);

        internal async Task CreatePlayerStats(uint id) =>
            await _playerDao.CreatePlayerStats(id);
    }
}