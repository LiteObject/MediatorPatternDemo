namespace MediatorPatternDemo.Web.Library.Quaries
{
    using MediatorPatternDemo.Web.Entities;

    using MediatR;

    /// <summary>
    /// The query.
    /// </summary>
    public class UserQuery : IRequest<User>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
