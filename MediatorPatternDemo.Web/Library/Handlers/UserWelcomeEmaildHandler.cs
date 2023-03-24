using MediatorPatternDemo.Web.Library.Events;
using MediatR;

namespace MediatorPatternDemo.Web.Library.Handlers
{
    /// <summary>
    /// For more examples:
    /// https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples/PingedHandler.cs
    /// </summary>
    public class UserWelcomeEmailHandler : INotificationHandler<UserCreated>
    {
        // private readonly ILogger<UserQueryHandler> logger;

        public UserWelcomeEmailHandler()
        {
        }

        public Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(notification);

            Console.WriteLine($"Invoked {nameof(UserWelcomeEmailHandler)} to handle {nameof(UserCreated)} event.");
            Console.WriteLine($"We are sending out an email welcoming the new user {notification.Name} ({notification.Email}).");

            return Task.CompletedTask;
        }
    }
}
