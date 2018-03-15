namespace Alore.Messenger.Models
{
    using API.Messenger.Models;

    public class MessengerFriend : IMessengerFriend
    {
        public int FriendId { get; set; }

        public int LastOnline { get; set; }

        public string Username { get; set; }

        public string Motto { get; set; }

        public bool HideOnline { get; set; }

        public bool HideInRoom { get; set; }
    }
}
