namespace MediatorPatternDemo.V3
{
    /// <summary>
    /// The team chatroom.
    /// </summary>
    internal class TeamChatroom : Chatroom
    {
        /// <summary>
        /// The members.
        /// </summary>
        private readonly List<TeamMember> members = new();

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="member">
        /// The member.
        /// </param>
        public override void Register(TeamMember member)
        {
            member.SetChatroom(this);
            this.members.Add(member);
        }

        /// <summary>
        /// The register members.
        /// </summary>
        /// <param name="teamMembers">
        /// The team members.
        /// </param>
        public void RegisterMembers(params TeamMember[] teamMembers)
        {
            teamMembers.ToList().ForEach(this.Register);
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public override void Send(string from, string message)
        {
            this.members.Where(m => m.Name != from).ToList().ForEach(m => m.Receive(from, message));
        }

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
        public override void SendTo<T>(string from, string message)
        {
            this.members.OfType<T>().Where(m => m.Name != from).ToList().ForEach(m => m.Receive(from, message));
        }
    }
}
