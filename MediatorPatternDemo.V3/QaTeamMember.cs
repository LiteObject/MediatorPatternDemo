namespace MediatorPatternDemo.V3
{
    internal class QaTeamMember : Member
    {
        public QaTeamMember(string name)
            : base(name)
        {
        }

        internal override void Receive(string from, string message)
        {
            Console.WriteLine($"{Name} ({nameof(QaTeamMember)}) has received a message.");
            base.Receive(from, message);
        }
    }
}
