namespace MediatorPatternDemo.V3
{
    using System;

    /// <summary>
    /// The QA team member.
    /// </summary>
    internal class QaTeamMember : TeamMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QaTeamMember"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public QaTeamMember(string name)
            : base(name)
        {
        }

        /// <summary>
        /// The receive.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        internal override void Receive(string from, string message)
        {
            Console.WriteLine($"{this.Name} ({nameof(QaTeamMember)}) has received a message.");
            base.Receive(from, message);
        }
    }
}
