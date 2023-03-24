namespace MediatorPatternDemo.V3
{
    internal class Program
    {
        public static void Main()
        {
            TeamChatroom teamChat = new();

            DevTeamMember joe = new("Joe");
            DevTeamMember david = new("David");
            DevTeamMember mohammed = new("Mohammed");

            QaTeamMember camila = new("Camila");

            teamChat.RegisterMembers(joe, david, camila, mohammed);

            joe.SendTo<DevTeamMember>("Can someone review my PR?");

            david.Send("Just a friendly reminder that I will be off tomorrow.");
            camila.Send($"Enjoy your day off.");
        }
    }
}
