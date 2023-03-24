namespace MediatorPatternDemo.V3
{
    internal class DevTeamMember : Member
    {
        public DevTeamMember(string name)
            : base(name)
        {
        }

        internal override void Receive(string from, string message)
        {
            Console.WriteLine($"{Name} ({nameof(DevTeamMember)}) has received a message.");
            base.Receive(from, message);
        }
    }
}
