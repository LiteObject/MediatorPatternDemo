namespace MediatorPatternDemo.V3
{
    /// <summary>
    /// The chatroom.
    /// </summary>
    internal abstract class Chatroom
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="member">
        /// The member.
        /// </param>
        public abstract void Register(TeamMember member);

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public abstract void Send(string from, string message);

        /// <summary>
        /// The send to.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        public abstract void SendTo<T>(string from, string message)
            where T : TeamMember;
    }
}
