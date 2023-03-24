namespace MediatorPatternDemo.V2.Structural
{
    internal class Mediator : MediatorBase
    {
        private readonly List<FriendBase> Friends = new();

        public void Register(FriendBase Friend)
        {
            Friend.SetMediator(this);
            Friends.Add(Friend);
        }

        public T CreateFriend<T>()
            where T : FriendBase, new()
        {
            // Encapsulate the creation and bidirectional communication
            T c = new();
            c.SetMediator(this);
            Friends.Add(c);
            return c;
        }

        public override void Send(string message, FriendBase fromFriend)
        {
            Friends.Where(c => c != fromFriend).ToList().ForEach(c => c.HandleNotification(message));
        }
    }
}
