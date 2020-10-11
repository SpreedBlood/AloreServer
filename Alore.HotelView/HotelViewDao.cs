namespace Alore.HotelView
{
    using Alore.API.Config;
    using Alore.API.Landing.Models;
    using Alore.API.Sql;
    using Alore.HotelView.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class LandingDao : AloreDao
    {
        public LandingDao(IConfigController configController) : base(configController)
        {
        }

        internal async Task<IList<IHallOfFamer>> GetHallOfFamers()
        {
            IList<IHallOfFamer> hallOfFamers = new List<IHallOfFamer>();
            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    while (await reader.ReadAsync())
                    {
                        hallOfFamers.Add(new HallOfFamer(reader));
                    }
                }, "SELECT id, rank, diamonds, username, figure FROM players ORDER BY diamonds LIMIT 10;");
            });

            return hallOfFamers;
        }
    }
}
