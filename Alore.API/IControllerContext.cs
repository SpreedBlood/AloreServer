namespace Alore.API
{
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
    }
}
