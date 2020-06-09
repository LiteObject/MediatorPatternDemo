namespace MediatorPatternDemo.Structural
{
    using System;

    /// <summary>
    /// The colleague 1.
    /// </summary>
    internal class Colleague1 : ColleagueBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Colleague1"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public Colleague1(MediatorBase mediator)
            : base(mediator)
        {
        }

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
