namespace MediatorPatternDemo.V2.Structural
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The mediator imp.
    /// </summary>
    internal class Mediator : MediatorBase
    {
        /// <summary>
        /// The colleagues.
        /// </summary>
        private readonly List<ColleagueBase> colleagues = new List<ColleagueBase>();

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="colleague">
        /// The colleague.
        /// </param>
        public void Register(ColleagueBase colleague)
        {
            colleague.SetMediator(this);
            this.colleagues.Add(colleague);
        }

        /// <summary>
        /// The create colleague.
        /// </summary>
        /// <typeparam name="T">
        /// The type.
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T CreateColleague<T>()
            where T : ColleagueBase, new()
        {
            // Encapsulate the creation and bidirectional communication
            var c = new T();
            c.SetMediator(this);
            this.colleagues.Add(c);
            return c;
        }

        /// <summary>
        /// The send.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="colleague">
        /// The colleague.
        /// </param>
        public override void Send(string message, ColleagueBase colleague)
        {
            this.colleagues.Where(c => c != colleague).ToList().ForEach(c => c.HandleNotification(message));
        }
    }
}
