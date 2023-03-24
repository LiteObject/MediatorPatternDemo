using MediatorPatternDemo.Web.Data;
using MediatorPatternDemo.Web.Entities;
using MediatorPatternDemo.Web.Exceptions;
using MediatorPatternDemo.Web.Library.Commands;
using MediatR;
using Newtonsoft.Json;

namespace MediatorPatternDemo.Web.Library.Handlers
{
    public class UserCommandHandler :
        IRequestHandler<CreateUserCommand, User>,
        IRequestHandler<UpdateUserCommand, User>
    {
        private readonly UserContext context;

        private readonly ILogger<UserQueryHandler> logger;

        public UserCommandHandler(UserContext context, ILogger<UserQueryHandler> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            Console.WriteLine($"Invoked {nameof(UserCommandHandler)} to handle {nameof(CreateUserCommand)} command. {JsonConvert.SerializeObject(request)} \n");

            User user = new()
            {
                Name = request.Name,
                Email = request.Email
            };

            _ = await context.Users.AddAsync(user, cancellationToken);
            int saveCount = await context.SaveChangesAsync(cancellationToken);

            Console.WriteLine($"Saved {saveCount} {nameof(User)}: {System.Text.Json.JsonSerializer.Serialize(user)}");
            return user;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request);

            Console.WriteLine($"Invoked {nameof(UserCommandHandler)} to handle {nameof(UpdateUserCommand)} command. {JsonConvert.SerializeObject(request)}\n");

            User? user = await context.Users.FindAsync(new object?[] { request.Id }, cancellationToken: cancellationToken);

            if (user is null)
            {
                throw new NotFoundException($"No {nameof(user)} found in the system with id {request?.Id}");
            }

            user.Name = request.Name;
            user.Email = request.Email;

            // this.context.Users.Update(user);
            _ = await context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
