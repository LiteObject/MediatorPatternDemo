namespace MediatorPatternDemo.Structural
{
    internal class FriendTwo : FriendBase
    {
        public FriendTwo(MediatorBase mediator)
            : base(mediator)
        {
        }

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"\n{nameof(FriendTwo)} has received a message:\n {message}");
        }
    }
}
