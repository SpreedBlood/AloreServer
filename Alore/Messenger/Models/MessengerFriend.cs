namespace Alore.Messenger.Models
{
    using API.Messenger.Models;
    using API.Sql;

    public class MessengerFriend : AloreModel, IMessengerFriend
    {
        //TODO:
        public int FriendId { get; set; }

        public int LastOnline { get; set; }

        public string Username { get; set; }

        public string Motto { get; set; }

        public bool HideOnline { get; set; }

        public bool HideInRoom { get; set; }
    }
}
