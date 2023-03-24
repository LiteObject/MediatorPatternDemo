namespace MediatorPatternDemo.Structural
{
    /// <summary>
    /// The Friend communicates only with the <see cref="MediatorBase"/> class.
    /// </summary>
    internal abstract class FriendBase
    {
        private readonly MediatorBase mediator;

        protected FriendBase(MediatorBase mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Send(string message)
        {
            this.mediator.Send(message, this);
        }

        public abstract void HandleNotification(string message);
    }
}
