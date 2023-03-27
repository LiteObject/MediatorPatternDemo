using Humanizer;

namespace MediatorPatternDemo.V2.Structural
{
    public class QualityEngineer : EmployeeBase
    {
        public override void HandleNotification(string message)
        {
            Console.WriteLine($"\n{base.Name} ({this.GetType().Name.Humanize()}) has received a message:\n[{DateTime.Now}] {message}");
        }
    }
}
