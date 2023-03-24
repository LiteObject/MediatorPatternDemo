namespace MediatorPatternDemo.Web.Library.Quaries
{
    using System.Collections.Generic;

    using MediatorPatternDemo.Web.Entities;

    using MediatR;

    /// <summary>
    /// The query - GET request.
    /// </summary>
    public class UserQuery : IRequest<User>, IRequest<IList<User>>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        ///  Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}
