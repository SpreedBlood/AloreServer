namespace Alore
{
    using Alore.API.Landing;
    using Alore.API.Navigator;
    using API;
    using API.Messenger;
    using API.Player;

    public class ControllerContext : IControllerContext
    {
        public IMessengerController MessengerController { get; set; }

        public IPlayerController PlayerController { get; set; }

        public INavigatorController NavigatorController { get; set; }

        public ILandingController LandingController { get; set; }
    }
}
