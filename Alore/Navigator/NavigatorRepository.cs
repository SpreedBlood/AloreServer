namespace Alore.Navigator
{
    using Alore.API.Navigator.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class NavigatorRepository
    {
        private readonly NavigatorDao _navigatorDao;

        private IList<INavigatorCategory> _unorderedCategories;

        private IList<INavigatorCategory> _categories;
        private IList<INavigatorCategory> _promotionCategories;

        public NavigatorRepository(NavigatorDao navigatorDao)
        {
            _navigatorDao = navigatorDao;
        }

        internal async Task<IList<INavigatorCategory>> GetNavigatorCategoriesAsync()
        {
            if (_categories != null) return _categories;
            await GetCategoriesIfNullAsync();

            IList<INavigatorCategory> categories = new List<INavigatorCategory>();
            
            foreach (INavigatorCategory navigatorCategory in _unorderedCategories)
            {
                if (navigatorCategory.CategoryType == CategoryType.Category)
                    categories.Add(navigatorCategory);
            }

            _categories = categories;
            return _categories;
        }

        internal async Task<IList<INavigatorCategory>> GetPromotionNavigatorCategoriesAsync()
        {
            if (_promotionCategories != null) return _promotionCategories;
            await GetCategoriesIfNullAsync();

            IList<INavigatorCategory> categories = new List<INavigatorCategory>();

            foreach (INavigatorCategory navigatorCategory in _unorderedCategories)
            {
                if (navigatorCategory.CategoryType == CategoryType.PromotionCategory)
                    categories.Add(navigatorCategory);
            }

            _promotionCategories = categories;
            return _promotionCategories;
        }

        private async Task GetCategoriesIfNullAsync()
        {
            if (_unorderedCategories == null)
                _unorderedCategories = await _navigatorDao.GetNavigatorCategoriesAsync();
        }
    }
}
