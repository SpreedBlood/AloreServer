﻿namespace Alore.Navigator
{
    using Alore.API.Navigator.Models;
    using Alore.API.Sql;
    using Alore.Navigator.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    internal class NavigatorDao : AloreDao
    {
        internal async Task<List<INavigatorCategory>> GetNavigatorCategoriesAsync()
        {
            List<INavigatorCategory> categories = new List<INavigatorCategory>();

            await CreateTransaction(async transaction =>
            {
                await Select(transaction, async reader =>
                {
                    while (await reader.ReadAsync())
                    {
                        NavigatorCategory category = new NavigatorCategory();
                        category.SetPropertyValues(reader);
                        categories.Add(category);
                    }
                }, "SELECT id, min_rank, public_name, category_type, identifier, category FROM navigator_categories ORDER BY id;");
            });

            return categories;
        }
    }
}