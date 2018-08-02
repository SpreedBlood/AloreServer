namespace Alore.Navigator
{
    using Alore.API.Navigator;
    using Alore.API.Navigator.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class NavigatorController : INavigatorController
    {
        private readonly NavigatorRepository _navigatorRepository;

        /// <summary>
        /// The navigator controller is used to serve data without manipulating.
        /// </summary>
        /// <param name="landingRepository">The navigator repository(singleton)</param>
        public NavigatorController(NavigatorRepository navigatorRepository)
        {
            _navigatorRepository = navigatorRepository;
        }

        public async Task<IList<INavigatorCategory>> GetNavigatorCategoriesAsync() =>
            await _navigatorRepository.GetNavigatorCategoriesAsync();

        public async Task<IList<INavigatorCategory>> GetEventCategoriesAsync() =>
            await _navigatorRepository.GetPromotionNavigatorCategoriesAsync();
    }
}
