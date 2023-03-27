using Humanizer;
using MediatorPatternDemo.V2.Structural;

namespace MediatorPatternDemo.V2
{
    internal class Program
    {
        public static void Main()
        {
            Mediator mediator = new();

            /* FriendOne friendOne = new();
            FriendTwo friendTwo = new();

            mediator.Register(friendOne);
            mediator.Register(friendTwo); */

            QualityEngineer employeeOne = mediator.CreateEmployee<QualityEngineer>("Jane");
            SoftwareEngineer employeeTwo = mediator.CreateEmployee<SoftwareEngineer>("Jon");

            employeeOne.Send($"Hello from {employeeOne.Name} ({employeeOne.GetType().Name.Humanize()})");
            employeeTwo.Send($"Hello from {employeeTwo.Name} ({employeeTwo.GetType().Name.Humanize()})");
        }
    }
}
