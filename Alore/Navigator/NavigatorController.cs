namespace Alore.Navigator
{
    using Alore.API.Navigator;
    using Alore.API.Navigator.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class NavigatorController : INavigatorController
    {
        private readonly NavigatorRepository _navigatorRepository;

        public NavigatorController()
        {
            // TODO: See PlayerController comment
            _navigatorRepository = new NavigatorRepository(new NavigatorDao());
        }

        public async Task<List<INavigatorCategory>> GetNavigatorCategoriesAsync() =>
            await _navigatorRepository.GetNavigatorCategoriesAsync();

        public async Task<List<INavigatorCategory>> GetEventCategoriesAsync() =>
            await _navigatorRepository.GetPromotionNavigatorCategoriesAsync();
    }
}
