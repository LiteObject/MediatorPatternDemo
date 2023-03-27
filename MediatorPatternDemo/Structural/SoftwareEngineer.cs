namespace MediatorPatternDemo.Structural
{
    internal class SoftwareEngineer : EmployeeBase
    {
        public SoftwareEngineer(MediatorBase mediator, string name)
            : base(mediator, name)
        {
        }

        public override void HandleNotification(string message)
        {
            Console.WriteLine($"\n{base.Name} ({this.GetType().Name}) has received a message:\n {message}");
        }
    }
}
