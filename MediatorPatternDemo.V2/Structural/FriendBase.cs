namespace MediatorPatternDemo.V2.Structural
{
    internal abstract class FriendBase
    {
        private MediatorBase? mediator;

        public virtual void Send(string message)
        {
            mediator?.Send(message, this);
        }

        public abstract void HandleNotification(string message);

        internal void SetMediator(MediatorBase m)
        {
            mediator = m;
        }
    }
}
