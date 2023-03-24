namespace MediatorPatternDemo.V2.Structural
{
    internal abstract class MediatorBase
    {
        public abstract void Send(string message, FriendBase fromFriend);
    }
}
