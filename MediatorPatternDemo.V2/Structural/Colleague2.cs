namespace MediatorPatternDemo.V2.Structural
{
    /// <summary>
    /// The Friend 2.
    /// </summary>
    internal class Friend2 : FriendBase
    {
        /// <summary>
        /// The handle notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"{nameof(Friend2)} has received a message:\n{message}");
        }
    }
}
