namespace MediatorPatternDemo.V2.Structural
{
    /// <summary>
    /// The mediator define communication between Friends
    /// </summary>
    internal abstract class MediatorBase
    {
        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="Friend">
        /// The Friend.
        /// </param>
        public abstract void Send(string message, FriendBase Friend);
    }
}
