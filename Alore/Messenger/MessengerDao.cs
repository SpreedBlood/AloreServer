namespace Alore.Messenger
{
    using Alore.API.Config;
    using API.Sql;

    internal class MessengerDao : AloreDao
    {
        public MessengerDao(IConfigController configController) : base(configController)
        {
        }
    }
}
