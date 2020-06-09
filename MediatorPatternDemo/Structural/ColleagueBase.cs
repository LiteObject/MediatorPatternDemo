namespace MediatorPatternDemo.Structural
{
    /// <summary>
    /// The colleague communicates only with the <see cref="MediatorBase"/> class.
    /// </summary>
    internal abstract class ColleagueBase
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly MediatorBase mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ColleagueBase"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        protected ColleagueBase(MediatorBase mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public virtual void Send(string message)
        {
            this.mediator.Send(message, this);
        }

        /// <summary>
        /// The handle notification - used when received a message.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public abstract void HandleNotification(string message);
    }
}
