namespace MediatorPatternDemo.V2.Structural
{
    /// <summary>
    /// The Friend 1.
    /// </summary>
    internal class Friend1 : FriendBase
    {
        /// <summary>
        /// The handle notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"{nameof(Friend1)} has received a message:\n{message}");
        }
    }
}
