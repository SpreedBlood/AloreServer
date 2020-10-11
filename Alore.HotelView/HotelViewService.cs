namespace Alore.HotelView
{
    using API;
    using API.Landing;
    using Microsoft.Extensions.DependencyInjection;

    public class LandingService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<LandingDao>();
            serviceCollection.AddSingleton<LandingRepository>();
            serviceCollection.AddSingleton<ILandingController, LandingController>();
        }
    }
}
