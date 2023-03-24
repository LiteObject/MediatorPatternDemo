namespace MediatorPatternDemo.V3
{
    /// <summary>
    /// The team member.
    /// </summary>
    internal abstract class TeamMember
    {
        /// <summary>
        /// The chat-room.
        /// </summary>
        private Chatroom chatroom;

        /// <summary>
        /// Initializes a new instance of the <see cref="TeamMember"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        protected TeamMember(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The set chatroom.
        /// </summary>
        /// <param name="chatroom">
        /// The chat-\room.
        /// </param>
        internal void SetChatroom(Chatroom chatroom)
        {
            this.chatroom = chatroom;
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        internal void Send(string message)
        {
            this.chatroom.Send(this.Name, message);
        }

        /// <summary>
        /// The send to.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        internal void SendTo<T>(string message)
            where T : TeamMember
        {
            this.chatroom.SendTo<T>(this.Name, message);
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
        internal virtual void Receive(string from, string message)
        {
            Console.WriteLine($"{from}: {message}\n");
        }
    }
}
