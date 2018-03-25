using Alore.API.Navigator.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alore.API.Navigator
{
    public interface INavigatorController
    {
        /// <summary>
        /// Get the navigator categories asynchronously.
        /// </summary>
        /// <returns>Return the list with navigator categories upon task completion.</returns>
        Task<List<INavigatorCategory>> GetNavigatorCategoriesAsync();

        /// <summary>
        /// Get the promoted navigator categories asynchronously.
        /// </summary>
        /// <returns>Return the list with promoted navigator categories upon task completion.</returns>
        Task<List<INavigatorCategory>> GetEventCategoriesAsync();
    }
}
