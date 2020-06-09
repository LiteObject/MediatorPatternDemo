using System;

namespace MediatorPatternDemo.V3
{
    /// <summary>
    /// The dev team member.
    /// </summary>
    internal class DevTeamMember : TeamMember
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DevTeamMember"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        public DevTeamMember(string name)
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
            Console.WriteLine($"{this.Name} ({nameof(DevTeamMember)}) has received a message.");
            base.Receive(from, message);
        }
    }
}
