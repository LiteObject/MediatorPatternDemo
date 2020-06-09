namespace MediatorPatternDemo.Structural
{
    /// <summary>
    /// The mediator imp.
    /// </summary>
    internal class Mediator : MediatorBase
    {
        /// <summary>
        /// Gets or sets the colleague 1.
        /// </summary>
        public Colleague1 Colleague1 { get; set; }

        /// <summary>
        /// Gets or sets the colleague 2.
        /// </summary>
        public Colleague2 Colleague2 { get; set; }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="colleague">
        /// The colleague.
        /// </param>
        public override void Send(string message, ColleagueBase colleague)
        {
            if (colleague == this.Colleague1)
            {
                this.Colleague2.HandleNotification(message);
            }
            else
            {
                this.Colleague1.HandleNotification(message);
            }
        }
    }
}
