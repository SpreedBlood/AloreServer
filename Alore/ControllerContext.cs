namespace Alore
{
    using API;
    using API.Messenger;
    using API.Player;

    public class ControllerContext : IControllerContext
    {
        public IMessengerController MessengerController { get; set; }

        public IPlayerController PlayerController { get; set; }
    }
}
