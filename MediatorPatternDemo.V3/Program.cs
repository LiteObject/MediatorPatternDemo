namespace MediatorPatternDemo.V3
{
    using System;

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
            var teamChat = new TeamChatroom();

            var will = new DevTeamMember("Will");
            var byron = new DevTeamMember("Byron");
            var geetha = new QaTeamMember("Geetha");

            teamChat.RegisterMembers(will, byron, geetha);

            byron.Send("Hey Geetha, are you ready for a quick huddle?");
            geetha.Send($"Yes Byron.");

            will.SendTo<DevTeamMember>("Can you review my PR?");
        }
    }
}
