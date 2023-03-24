namespace MediatorPatternDemo.V2.Structural
{
    /// <summary>
    /// The mediator imp.
    /// </summary>
    internal class Mediator : MediatorBase
    {
        /// <summary>
        /// The Friends.
        /// </summary>
        private readonly List<FriendBase> Friends = new();

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="Friend">
        /// The Friend.
        /// </param>
        public void Register(FriendBase Friend)
        {
            Friend.SetMediator(this);
            this.Friends.Add(Friend);
        }

        /// <summary>
        /// The create Friend.
        /// </summary>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T CreateFriend<T>()
            where T : FriendBase, new()
        {
            // Encapsulate the creation and bidirectional communication
            T c = new();
            c.SetMediator(this);
            this.Friends.Add(c);
            return c;
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="Friend">
        /// The Friend.
        /// </param>
        public override void Send(string message, FriendBase Friend)
        {
            this.Friends.Where(c => c != Friend).ToList().ForEach(c => c.HandleNotification(message));
        }
    }
}
