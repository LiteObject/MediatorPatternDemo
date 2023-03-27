namespace MediatorPatternDemo.V2.Structural
{
    public abstract class EmployeeBase
    {
        public string Name { get; set; } = string.Empty;

        private MediatorBase? mediator;

        public abstract void HandleNotification(string message);

        public void SetMediator(MediatorBase m)
        {
            mediator = m;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public virtual void Send(string message)
        {
            this.mediator?.Send(message, this);
        }
    }
}
