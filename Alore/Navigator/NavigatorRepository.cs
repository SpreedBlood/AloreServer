namespace Alore.Navigator
{
    using Alore.API.Navigator.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class NavigatorRepository
    {
        private readonly NavigatorDao _navigatorDao;
        private List<INavigatorCategory> _categories;
        private List<INavigatorCategory> _promotionCategories;

        internal NavigatorRepository(NavigatorDao navigatorDao)
        {
            _navigatorDao = navigatorDao;
        }

        internal async Task<List<INavigatorCategory>> GetNavigatorCategoriesAsync()
        {
            if (_categories != null) return _categories;

            _categories = await _navigatorDao.GetNavigatorCategoriesAsync();
            return _categories;
        }

        internal async Task<List<INavigatorCategory>> GetPromotionNavigatorCategoriesAsync()
        {
            if (_promotionCategories != null) return _promotionCategories;

            _promotionCategories = await _navigatorDao.GetPromotionCategoriesAsync();
            return _promotionCategories;
        }
    }
}
