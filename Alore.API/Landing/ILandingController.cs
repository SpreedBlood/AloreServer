using Alore.API.Landing.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alore.API.Landing
{
    public interface ILandingController
    {
        /// <summary>
        /// Get the top 10 players with highest diamonds.
        /// </summary>
        /// <returns>the top 10 players upon task completion.</returns>
        Task<List<IHallOfFamer>> GetHallOfFamersAsync();
    }
}
