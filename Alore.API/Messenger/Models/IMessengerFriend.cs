namespace Alore.API.Messenger.Models
{
    public interface IMessengerFriend
    {
        int FriendId { get; set; }

        int LastOnline { get; set; }

        string Username { get; set; }

        string Motto { get; set; }

        bool HideOnline { get; set; }

        bool HideInRoom { get; set; }
    }
}
