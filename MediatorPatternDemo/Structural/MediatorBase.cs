namespace MediatorPatternDemo.Structural
{
    internal abstract class MediatorBase
    {
        public abstract void Send(string message, EmployeeBase from);
    }
}
