using MediatorPatternDemo.Web.Library.Events;
using MediatR;

namespace MediatorPatternDemo.Web.Library.Handlers
{
    public class UserAccessSetupHandler : INotificationHandler<UserCreated>
    {
        // private readonly ILogger<UserAccessSetupHandler> logger;

        public UserAccessSetupHandler()
        {
        }

        public Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(notification, nameof(notification));

            Console.WriteLine($"Invoked {nameof(UserAccessSetupHandler)} to handle {nameof(UserAccessSetupHandler)} event.");
            Console.WriteLine($"We are setting up user \"{notification.Name}\"");

            return Task.CompletedTask;
        }
    }
}
