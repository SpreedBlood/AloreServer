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
    }
}