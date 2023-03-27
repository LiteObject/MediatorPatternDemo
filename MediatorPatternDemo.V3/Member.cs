namespace MediatorPatternDemo.V3
{
    internal abstract class Member
    {
        private ChatroomBase? chatroom;

        protected Member(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }

        public string Name { get; }

        public void SetChatroom(ChatroomBase chatroom)
        {
            ArgumentNullException.ThrowIfNull(chatroom, nameof(chatroom));
            this.chatroom = chatroom;
        }

        internal void Send(string message)
        {
            if (chatroom == null)
            {
                throw new InvalidOperationException($"Assign a chatroom (using {nameof(SetChatroom)} method) before invoking {nameof(Send)}");
            }

            chatroom.Send(Name, message);
        }

        internal void SendTo<T>(string message)
            where T : Member
        {
            if (chatroom == null)
            {
                throw new InvalidOperationException($"Assign a chatroom (using {nameof(SetChatroom)} method) before invoking {nameof(Send)}");
            }

            chatroom.SendTo<T>(Name, message);
        }

        internal virtual void Receive(string from, string message)
        {
            Console.WriteLine($"{from}: {message}\n");
        }
    }
}
