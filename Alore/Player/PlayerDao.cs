namespace Alore.Player
{
    using System.Threading.Tasks;
    using API.Sql;
    using Models;

    public class PlayerDao : AloreDao
    {
        public async Task<Player> GetPlayerByIdAsync(uint id)
        {
            Player player = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        player = new Player();
                        player.SetPropertyValues(reader);
                    }
                }, "SELECT id, credits, duckets, diamonds, username, auth_ticket, figure, gender, motto FROM players WHERE id = @0 LIMIT 1;", id);
            });
            return player;
        }

        public async Task<Player> GetPlayerBySsoAsync(string sso)
        {
            Player player = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        player = new Player();
                        player.SetPropertyValues(reader);
                    }
                }, "SELECT id, credits, duckets, diamonds, username, auth_ticket, figure, gender, motto FROM players WHERE auth_ticket = @0 LIMIT 1;", sso);
            });
            return player;
        }

        public async Task<PlayerSettings> GetPlayerSettingsByIdAsync(uint id)
        {
            PlayerSettings playerSettings = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        playerSettings = new PlayerSettings();
                        playerSettings.SetPropertyValues(reader);
                    }
                }, "SELECT navi_x, navi_y, navi_width, navi_height, navi_hide_searches FROM player_settings WHERE player_id = @0 LIMIT 1;", id);
            });

            return playerSettings;
        }

        public async Task CreatePlayerSettings(uint id)
        {
            await CreateTransaction(async transaction =>
            {
                await Insert(transaction, "INSERT INTO player_settings(player_id) VALUES(@0)", id);
            });
        }
    }
}