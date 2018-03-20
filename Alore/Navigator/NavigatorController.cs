namespace Alore.Navigator
{
    using Alore.API.Navigator;
    using Alore.API.Navigator.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class NavigatorController : INavigatorController
    {
        private readonly NavigatorRepository _navigatorRepository;

        internal NavigatorController(NavigatorRepository navigatorRepository)
        {
            _navigatorRepository = navigatorRepository;
        }

        public async Task<List<INavigatorCategory>> GetNavigatorCategoriesAsync() =>
            await _navigatorRepository.GetNavigatorCategoriesAsync();

        public async Task<List<INavigatorCategory>> GetNavigatorPromoterCategoriesAsync() =>
            await _navigatorRepository.GetPromotionNavigatorCategoriesAsync();
    }
}
