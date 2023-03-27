namespace MediatorPatternDemo.Structural
{
    internal class QualityEngineer : EmployeeBase
    {
        public QualityEngineer(MediatorBase mediator, string name)
            : base(mediator, name)
        {
        }

        public override void HandleNotification(string message)
        {
            // Console.WriteLine($"\n{nameof(QualityEngineer)} has received a message:\n {message}");
            Console.WriteLine($"\n{base.Name} ({this.GetType().Name}) has received a message:\n {message}");
        }
    }
}
