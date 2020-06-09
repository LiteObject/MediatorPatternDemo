namespace MediatorPatternDemo.Structural
{
    /// <summary>
    /// The mediator define communication between colleagues
    /// </summary>
    internal abstract class MediatorBase
    {
        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="colleague">
        /// The colleague.
        /// </param>
        public abstract void Send(string message, ColleagueBase colleague);
    }
}
