namespace Alore.API
{
    using Alore.API.Tasks;
    using Microsoft.Extensions.DependencyInjection;

    public static class Utils
    {
        public static void SetupAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<TaskFactory>();
        }
    }
}
