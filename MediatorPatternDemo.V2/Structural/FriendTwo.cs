namespace MediatorPatternDemo.V2.Structural
{
    internal class FriendTwo : FriendBase
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"\n{nameof(FriendTwo)} has received a message:\n {message}");
        }
    }
}
