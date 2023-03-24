namespace MediatorPatternDemo.V3
{
    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
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
