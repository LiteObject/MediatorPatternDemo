using Humanizer;
using MediatorPatternDemo.Structural;

namespace MediatorPatternDemo
{
    internal class Program
    {
        public static void Main()
        {
            Mediator mediator = new();

            SoftwareEngineer employeeOne = new(mediator, "Joe");

            QualityEngineer employeeTwo = new(mediator, "Vani");

            mediator.EmployeeOne = employeeOne;
            mediator.EmployeeTwo = employeeTwo;

            employeeOne.Send($"Hello Word from {employeeOne.Name} ({employeeOne.GetType().Name.Humanize()})");
            employeeTwo.Send($"Hello Word from {employeeTwo.Name} ({employeeTwo.GetType().Name.Humanize()})");
        }
    }
}
