namespace Alore.Item
{
    using Alore.API;
    using Alore.API.Item;
    using Microsoft.Extensions.DependencyInjection;

    internal class ItemService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ItemDao>();
            serviceCollection.AddSingleton<ItemRepository>();
            serviceCollection.AddSingleton<IItemController, ItemController>();
        }
    }
}
