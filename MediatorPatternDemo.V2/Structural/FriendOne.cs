namespace MediatorPatternDemo.V2.Structural
{
    internal class FriendOne : FriendBase
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"\n{nameof(FriendOne)} has received a message:\n {message}");
        }
    }
}
