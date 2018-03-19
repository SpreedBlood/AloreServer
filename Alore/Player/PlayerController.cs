namespace Alore.Player
{
    using System.Threading.Tasks;
    using API.Player;
    using API.Player.Models;

    public class PlayerController : IPlayerController
    {
        private readonly PlayerRepostiory _playerRepostiory;

        public PlayerController(PlayerRepostiory playerRepostiory)
        {
            _playerRepostiory = playerRepostiory;
        }

        public async Task AddPlayerSettingsAsync(uint id) =>
            await _playerRepostiory.CreatePlayerSettings(id);

        public async Task<IPlayer> GetPlayerByIdAsync(uint id) =>
            await _playerRepostiory.GetPlayerById(id);

        public async Task<IPlayer> GetPlayerBySsoAsync(string sso) =>
            await _playerRepostiory.GetPlayerBySso(sso);

        public async Task<IPlayerSettings> GetPlayerSettingsByIdAsync(uint id) =>
            await _playerRepostiory.GetPlayerSettingsById(id);
    }
}