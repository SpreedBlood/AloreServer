namespace Alore.Player
{
    using System.Threading.Tasks;
    using API.Player;
    using API.Player.Models;

    internal class PlayerController : IPlayerController
    {
        private readonly PlayerRepostiory _playerRepostiory;

        public PlayerController()
        {
            // TODO: Make this injectable via the servicecollection. Also need an interface!
            _playerRepostiory = new PlayerRepostiory(new PlayerDao());
        }

        public async Task AddPlayerSettingsAsync(uint id) =>
            await _playerRepostiory.CreatePlayerSettings(id);

        public async Task AddPlayerStatsAsync(uint id) =>
            await _playerRepostiory.CreatePlayerStats(id);

        public async Task<IPlayer> GetPlayerByIdAsync(uint id) =>
            await _playerRepostiory.GetPlayerById(id);

        public async Task<IPlayer> GetPlayerBySsoAsync(string sso) =>
            await _playerRepostiory.GetPlayerBySso(sso);

        public async Task<IPlayerSettings> GetPlayerSettingsByIdAsync(uint id) =>
            await _playerRepostiory.GetPlayerSettingsById(id);

        public async Task<IPlayerStats> GetPlayerStatsByIdAsync(uint id) =>
            await _playerRepostiory.GetPlayerStatsById(id);
    }
}