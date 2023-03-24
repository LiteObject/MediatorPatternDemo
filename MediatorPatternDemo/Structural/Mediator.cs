namespace MediatorPatternDemo.Structural
{
    internal class Mediator : MediatorBase
    {
        public FriendOne? FriendOne { get; set; }

        public FriendTwo? FriendTwo { get; set; }

        public override void Send(string message, FriendBase fromFriend)
        {
            if (fromFriend == FriendOne)
            {
                FriendTwo?.HandleNotification(message);
            }
            else
            {
                FriendOne?.HandleNotification(message);
            }
        }
    }
}
