namespace Alore.Player
{
    using System.Threading.Tasks;
    using Alore.API.Config;
    using Alore.API.Player.Models;
    using API.Sql;
    using Models;

    internal class PlayerDao : AloreDao
    {
        public PlayerDao(IConfigController configController) : base(configController)
        {
        }

        internal async Task<IPlayer> GetPlayerById(uint id)
        {
            IPlayer player = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        player = new Player(reader);
                    }
                }, "SELECT id, credits, duckets, diamonds, rank, username, auth_ticket, figure, gender, motto FROM players WHERE id = @0 LIMIT 1;", id);
            });
            return player;
        }

        internal async Task<IPlayer> GetPlayerBySso(string sso)
        {
            IPlayer player = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        player = new Player(reader);
                    }
                }, "SELECT id, credits, duckets, diamonds, rank, username, auth_ticket, figure, gender, motto FROM players WHERE auth_ticket = @0 LIMIT 1;", sso);
            });
            return player;
        }

        internal async Task<IPlayerSettings> GetPlayerSettingsById(uint id)
        {
            IPlayerSettings playerSettings = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        playerSettings = new PlayerSettings(reader);
                    }
                }, "SELECT navi_x, navi_y, navi_width, navi_height, navi_hide_searches FROM player_settings WHERE player_id = @0 LIMIT 1;", id);
            });

            return playerSettings;
        }

        internal async Task CreatePlayerSettings(uint id)
        {
            await CreateTransaction(async transaction =>
            {
                await Insert(transaction, "INSERT INTO player_settings(player_id) VALUES(@0)", id);
            });
        }

        internal async Task<IPlayerStats> GetPlayerStatsById(uint id)
        {
            IPlayerStats playerStats = null;
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    if (await reader.ReadAsync())
                    {
                        playerStats = new PlayerStats(reader);
                    }
                }, "SELECT respect, daily_respect, daily_pet_points FROM player_stats WHERE player_id = @0 LIMIT 1;", id);
            });

            return playerStats;
        }

        internal async Task CreatePlayerStats(uint id)
        {
            await CreateTransaction(async transaction =>
            {
                await Insert(transaction, "INSERT INTO player_stats(player_id) VALUES(@0)", id);
            });
        }
    }
}