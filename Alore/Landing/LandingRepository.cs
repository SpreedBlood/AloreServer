namespace Alore.Landing
{
    using Alore.API.Landing.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class LandingRepository
    {
        private readonly LandingDao _landingDao;
        private List<IHallOfFamer> _hallOfFamers;

        internal LandingRepository(LandingDao dao)
        {
            _landingDao = dao;
        }

        internal async Task<List<IHallOfFamer>> GetHallOfFamersAsync()
        {
            if (_hallOfFamers != null) return _hallOfFamers;

            _hallOfFamers = await _landingDao.GetHallOfFamers();
            return _hallOfFamers;
        }
    }
}
