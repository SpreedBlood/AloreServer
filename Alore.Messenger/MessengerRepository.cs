namespace Alore.Messenger
{
    internal class MessengerRepository
    {
        private readonly MessengerDao _messengerDao;

        internal MessengerRepository(MessengerDao messengerDao)
        {
            _messengerDao = messengerDao;
        }

    }
}
