namespace MediatorPatternDemo.V2.Structural
{
    internal class Mediator : MediatorBase
    {
        private readonly List<EmployeeBase> Employees = new();

        public void Register(EmployeeBase employee)
        {
            employee.SetMediator(this);
            Employees.Add(employee);
        }

        public T CreateEmployee<T>(string name)
            where T : EmployeeBase, new()
        {
            // Encapsulate the creation and bidirectional communication
            T c = new();
            c.SetMediator(this);
            c.SetName(name);
            Employees.Add(c);
            return c;
        }

        public override void Send(string message, EmployeeBase fromFriend)
        {
            Employees.Where(c => c != fromFriend).ToList().ForEach(c => c.HandleNotification(message));
        }
    }
}
