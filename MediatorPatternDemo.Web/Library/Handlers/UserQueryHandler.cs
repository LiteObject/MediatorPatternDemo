using MediatorPatternDemo.Web.Data;
using MediatorPatternDemo.Web.Entities;
using MediatorPatternDemo.Web.Library.Quaries;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace MediatorPatternDemo.Web.Library.Handlers
{
    public class UserQueryHandler : IRequestHandler<UserQuery, IList<User>>
    {
        private readonly UserContext _context;

        // private readonly ILogger<UserQueryHandler> _logger;

        public UserQueryHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> Handle(UserQuery? request, CancellationToken cancellationToken)
        {
            //if (request is null)
            //{
            //    Console.WriteLine($"{nameof(request)} cannot be null");
            //    return new List<User>();
            //}

            Console.WriteLine($"Inside the handler. Not necessary since we have logging as pipeline behavior. Request Query: {JsonConvert.SerializeObject(request)}\n");

            List<User> users = request?.Name?.Length > 0
                ? await _context.Users.Where(u => u.Name.Contains(request.Name)).ToListAsync(cancellationToken: cancellationToken)
                : await _context.Users.ToListAsync(cancellationToken: cancellationToken);

            // Business logic here
            // this.context.Users.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);

            return users;
        }
    }
}
