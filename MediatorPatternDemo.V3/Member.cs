﻿namespace MediatorPatternDemo.V3
{
    internal abstract class Member
    {
        private Chatroom? chatroom;

        protected Member(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            this.Name = name;
        }

        public string Name { get; }

        public void SetChatroom(Chatroom chatroom)
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

            this.chatroom.Send(this.Name, message);
        }

        internal void SendTo<T>(string message)
            where T : Member
        {
            if (chatroom == null)
            {
                throw new InvalidOperationException($"Assign a chatroom (using {nameof(SetChatroom)} method) before invoking {nameof(Send)}");
            }

            this.chatroom.SendTo<T>(this.Name, message);
        }

        internal virtual void Receive(string from, string message)
        {
            Console.WriteLine($"{from}: {message}\n");
        }
    }
}
