namespace MediatorPatternDemo.Structural
{
    internal class FriendOne : FriendBase
    {
        public FriendOne(MediatorBase mediator)
            : base(mediator)
        {
        }

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"\n{nameof(FriendOne)} has received a message:\n {message}");
        }
    }
}
