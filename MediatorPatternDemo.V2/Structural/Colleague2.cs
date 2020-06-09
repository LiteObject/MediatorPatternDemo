namespace MediatorPatternDemo.V2.Structural
{
    using System;

    /// <summary>
    /// The colleague 2.
    /// </summary>
    internal class Colleague2 : ColleagueBase
    {
        /// <summary>
        /// The handle notification.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"{nameof(Colleague2)} has received a message:\n{message}");
        }
    }
}
