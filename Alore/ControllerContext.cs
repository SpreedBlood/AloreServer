namespace Alore
{
    using API.Landing;
    using API.Navigator;
    using API;
    using API.Messenger;
    using API.Player;
    using API.Room;

    public class ControllerContext : IControllerContext
    {
        public IMessengerController MessengerController { get; set; }

        public IPlayerController PlayerController { get; set; }

        public INavigatorController NavigatorController { get; set; }

        public ILandingController LandingController { get; set; }

        public IRoomController RoomController { get; set; }
    }
}