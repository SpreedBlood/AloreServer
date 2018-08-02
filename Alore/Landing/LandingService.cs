namespace Alore.Landing
{
    using API;
    using API.Landing;
    using Microsoft.Extensions.DependencyInjection;

    internal class LandingService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<LandingDao>();
            serviceCollection.AddSingleton<LandingRepository>();
            serviceCollection.AddSingleton<ILandingController, LandingController>();
        }
    }
}
