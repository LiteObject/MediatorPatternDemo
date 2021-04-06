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
        private readonly UserContext _context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<UserQueryHandler> _logger;

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
            this._context = context;
            this._logger = logger;
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
            if (request is null)
            {
                this._logger.LogWarning($"{nameof(request)} cannot be null");
                return new List<User>();
            }

            this._logger.LogInformation($">>>>> Request Query: {JsonConvert.SerializeObject(request)}\n");

            List<User> users;

            // Business logic here
            // this.context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
            if (request?.Id > 0)
            {
                users = await this._context.Users.Where(u => u.Id == request.Id).ToListAsync(cancellationToken: cancellationToken);
            }
            else
            {
                users = await this._context.Users.ToListAsync(cancellationToken: cancellationToken);
            }

            return users;
        }
    }
}
