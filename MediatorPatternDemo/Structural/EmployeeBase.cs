namespace MediatorPatternDemo.Structural
{
    /// <summary>
    /// The Friend communicates only with the <see cref="MediatorBase"/> class.
    /// </summary>
    internal abstract class EmployeeBase
    {
        public string Name { get; init; }

        private readonly MediatorBase mediator;

        protected EmployeeBase(MediatorBase mediator, string name)
        {
            this.mediator = mediator;
            this.Name = name;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }

        public abstract void HandleNotification(string message);
    }
}
