using MediatorPatternDemo.Web.Data;
using MediatorPatternDemo.Web.Entities;
using MediatorPatternDemo.Web.Library.Quaries;

using MediatR;

using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

namespace MediatorPatternDemo.Web.Library.Handlers
{
    public class UserQueryHandler :
        IRequestHandler<UserQuery, IList<User>>,
        IRequestHandler<UserByIdQuery, User?>
    {
        private readonly UserContext _context;

        // private readonly ILogger<UserQueryHandler> _logger;

        public UserQueryHandler(UserContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> Handle(UserQuery? request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Inside the handler. Not necessary since we have logging as pipeline behavior. Request Query: {JsonConvert.SerializeObject(request)}\n");

            List<User> users = request switch
            {
                { Name.Length: > 1, Email.Length: > 1 } => await _context.Users.Where(u => u.Name == request.Name || u.Email == request.Email).ToListAsync(cancellationToken),
                { Name: null } => await _context.Users.Where(u => u.Email == request.Email).ToListAsync(cancellationToken: cancellationToken),
                { Email: null } => await _context.Users.Where(u => u.Name == request.Name).ToListAsync(cancellationToken: cancellationToken),
                _ => await _context.Users.ToListAsync(cancellationToken: cancellationToken)
            };

            return users;
        }

        public async Task<User?> Handle(UserByIdQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            Console.WriteLine($"Inside the handler. Not necessary since we have logging as pipeline behavior. Request Query: {JsonConvert.SerializeObject(request)}\n");

            User? user = await _context.Users.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);
            return user;
        }
    }
}
