namespace Alore.API
{
    using Microsoft.Extensions.DependencyInjection;

    public interface IService
    {
        //void InitializeEvents();

        void ConfigureServices(IServiceCollection serviceCollection);
    }
}