namespace MediatorPatternDemo.V3
{
    internal class TeamChatroom : Chatroom
    {
        private readonly List<Member> members = new();

        public override void Register(Member member)
        {
            member.SetChatroom(this);
            this.members.Add(member);
        }

        public void RegisterMembers(params Member[] teamMembers)
        {
            teamMembers.ToList().ForEach(this.Register);
        }

        public override void Send(string from, string message)
        {
            this.members.Where(m => m.Name != from).ToList().ForEach(m => m.Receive(from, message));
        }

        public override void SendTo<T>(string from, string message)
        {
            this.members.OfType<T>().Where(m => m.Name != from).ToList().ForEach(m => m.Receive(from, message));
        }
    }
}
