namespace Alore.HotelView
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Alore.API.Landing;
    using Alore.API.Landing.Models;

    internal class LandingController : ILandingController
    {
        private readonly LandingRepository _landingRepository;

        /// <summary>
        /// The landing controller is used to serve data without manipulating.
        /// </summary>
        /// <param name="landingRepository">The landing repository(singleton)</param>
        public LandingController(LandingRepository landingRepository)
        {
            _landingRepository = landingRepository;
        }

        public async Task<IList<IHallOfFamer>> GetHallOfFamersAsync() =>
            await _landingRepository.GetHallOfFamersAsync();
    }
}
