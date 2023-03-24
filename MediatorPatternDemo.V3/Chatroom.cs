namespace MediatorPatternDemo.V3
{
    internal abstract class Chatroom
    {
        public abstract void Register(Member member);

        public abstract void Send(string from, string message);

        public abstract void SendTo<T>(string from, string message)
            where T : Member;
    }
}
