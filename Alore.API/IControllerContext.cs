namespace Alore.API
{
    using Alore.API.Landing;
    using Alore.API.Navigator;
    using Messenger;
    using Player;

    public interface IControllerContext
    {
        //Important notes: The controller context is only
        //initialized once and that is during build so it's
        //all singletons.

        /// <summary>
        /// Get the player controller.
        /// </summary>
        IPlayerController PlayerController { get; set; }

        /// <summary>
        /// Get the messenger controller.
        /// </summary>
        IMessengerController MessengerController { get; set; }

        /// <summary>
        /// The navigator controller.
        /// </summary>
        INavigatorController NavigatorController { get; set; }

        /// <summary>
        /// The landing view manager controller.
        /// </summary>
        ILandingController LandingController { get; set; }
    }
}
