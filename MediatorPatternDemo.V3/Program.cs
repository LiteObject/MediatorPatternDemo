namespace MediatorPatternDemo.V3
{
    internal class Program
    {
        public static void Main()
        {
            TeamChatroom teamChat = new();

            DevTeamMember mohammed = new("Mohammed");
            DevTeamMember gavin = new("Gavin");
            QaTeamMember camila = new("Camila");

            teamChat.RegisterMembers(mohammed, gavin, camila);

            mohammed.Send("Hey, are you ready for a demo?");
            camila.Send($"Yes Byron.");

            camila.SendTo<DevTeamMember>("Can you review my PR?");
        }
    }
}
