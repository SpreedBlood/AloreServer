namespace Alore.Landing
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Alore.API.Landing;
    using Alore.API.Landing.Models;

    internal class LandingController : ILandingController
    {
        private readonly LandingRepository _landingRepository;

        internal LandingController(LandingRepository landingRepository)
        {
            _landingRepository = landingRepository;
        }

        public async Task<List<IHallOfFamer>> GetHallOfFamersAsync() =>
            await _landingRepository.GetHallOfFamersAsync();
    }
}
