namespace MediatorPatternDemo.V2.Structural
{
    public abstract class MediatorBase
    {
        public abstract void Send(string message, EmployeeBase fromFriend);
    }
}
