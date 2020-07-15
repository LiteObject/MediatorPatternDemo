namespace MediatorPatternDemo.Web.Library.Handlers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatorPatternDemo.Web.Data;
    using MediatorPatternDemo.Web.Entities;
    using MediatorPatternDemo.Web.Library.Quaries;

    using MediatR;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    /// <summary>
    /// The user handler.
    /// </summary>
    public class UserQueryHandler : IRequestHandler<UserQuery, IList<User>>
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly UserContext context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<UserQueryHandler> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserQueryHandler"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public UserQueryHandler(UserContext context, ILogger<UserQueryHandler> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IList<User>> Handle(UserQuery request, CancellationToken cancellationToken)
        {
            this.logger.LogDebug($"Request Query: {JsonConvert.SerializeObject(request)}\n");

            List<User> users;

            // Business logic here
            // this.context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
            if (request != null && request.Id > 0)
            {
                users = await this.context.Users.Where(u => u.Id == request.Id).ToListAsync(cancellationToken: cancellationToken);
            }
            else
            {
                users = await this.context.Users.ToListAsync(cancellationToken: cancellationToken);
            }

            return users;
        }
    }
}
