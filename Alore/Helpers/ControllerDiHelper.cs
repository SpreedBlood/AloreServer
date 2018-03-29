using Alore.API.Landing;
using Alore.API.Messenger;
using Alore.API.Navigator;
using Alore.API.Player;
using Alore.API.Room;
using Alore.Landing;
using Alore.Messenger;
using Alore.Navigator;
using Alore.Player;
using Alore.Room;
using Microsoft.Extensions.DependencyInjection;

namespace Alore.Helpers
{
    public static class ControllerDiHelper
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // TODO: Could be singleton with scoped dao's when it's implemented with more abstraction
            serviceCollection.AddScoped<IPlayerController, PlayerController>();
            serviceCollection.AddScoped<ILandingController, LandingController>();
            serviceCollection.AddScoped<IMessengerController, MessengerController>();
            serviceCollection.AddScoped<INavigatorController, NavigatorController>();
            serviceCollection.AddScoped<IRoomController, RoomController>();
        }
    }
}