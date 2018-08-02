namespace Alore.Player
{
    using API;
    using API.Player;
    using Microsoft.Extensions.DependencyInjection;

    internal class PlayerService : IService
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<PlayerDao>();
            serviceCollection.AddSingleton<PlayerRepostiory>();
            serviceCollection.AddSingleton<IPlayerController, PlayerController>();
        }
    }
}
