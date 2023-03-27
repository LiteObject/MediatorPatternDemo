namespace MediatorPatternDemo.Structural
{
    internal class Mediator : MediatorBase
    {
        public SoftwareEngineer? EmployeeOne { get; set; }

        public QualityEngineer? EmployeeTwo { get; set; }

        public override void Send(string message, EmployeeBase from)
        {
            if (from == EmployeeOne)
            {
                EmployeeTwo?.HandleNotification(message);
            }
            else
            {
                EmployeeOne?.HandleNotification(message);
            }
        }
    }
}
