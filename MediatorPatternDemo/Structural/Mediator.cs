namespace MediatorPatternDemo.Structural
{
    internal class Mediator : MediatorBase
    {
        public FriendOne? FriendOne { get; set; }

        public FriendTwo? FriendTwo { get; set; }

        public override void Send(string message, FriendBase fromFriend)
        {
            if (fromFriend == this.FriendOne)
            {
                this.FriendTwo?.HandleNotification(message);
            }
            else
            {
                this.FriendOne?.HandleNotification(message);
            }
        }
    }
}
