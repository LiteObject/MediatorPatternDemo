using Humanizer;
using MediatorPatternDemo.Structural;

namespace MediatorPatternDemo
{
    internal class Program
    {
        public static void Main()
        {
            Mediator mediator = new();

            SoftwareEngineer employeeOne = new(mediator, "Jon");

            QualityEngineer employeeTwo = new(mediator, "Jane");

            mediator.EmployeeOne = employeeOne;
            mediator.EmployeeTwo = employeeTwo;

            employeeOne.Send($"Hello from {employeeOne.Name} ({employeeOne.GetType().Name.Humanize()})");
            employeeTwo.Send($"Hello from {employeeTwo.Name} ({employeeTwo.GetType().Name.Humanize()})");
        }
    }
}
