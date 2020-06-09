namespace MediatorPatternDemo.V2.Structural
{
    /// <summary>
    /// The colleague communicates only with the <see cref="MediatorBase"/> class.
    /// </summary>
    internal abstract class ColleagueBase
    {
        /// <summary>
        /// The mediator.
        /// </summary>
        private MediatorBase mediator;
        
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

        /// <summary>
        /// The set mediator.
        /// </summary>
        /// <param name="m">
        /// The mediator.
        /// </param>
        internal void SetMediator(MediatorBase m)
        {
            this.mediator = m;
        }
    }
}
