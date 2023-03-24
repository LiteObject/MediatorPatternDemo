namespace MediatorPatternDemo.V2.Structural
{
    /// <summary>
    /// The colleague 1.
    /// </summary>
    internal class Colleague1 : ColleagueBase
    {
        /// <summary>
        /// The handle notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"{nameof(Colleague1)} has received a message:\n{message}");
        }
    }
}
