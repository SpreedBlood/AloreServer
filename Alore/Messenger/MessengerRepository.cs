namespace Alore.Messenger
{
    internal class MessengerRepository
    {
        private readonly MessengerContext _messengerContext;

        internal MessengerRepository(MessengerContext messengerContext)
        {
            _messengerContext = messengerContext;
        }

    }
}
