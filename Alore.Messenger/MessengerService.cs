namespace Alore.Messenger
{
    using API;
    using API.Messenger;
    using Microsoft.Extensions.DependencyInjection;

    public class MessengerService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IMessengerController, MessengerController>();
        }
    }
}