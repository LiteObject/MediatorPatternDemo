namespace MediatorPatternDemo.Structural
{
    using System;

    /// <summary>
    /// The colleague 2.
    /// </summary>
    internal class Colleague2 : ColleagueBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Colleague2"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        public Colleague2(MediatorBase mediator)
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
            Console.WriteLine($"{nameof(Colleague2)} has received a message:\n{message}");
        }
    }
}
