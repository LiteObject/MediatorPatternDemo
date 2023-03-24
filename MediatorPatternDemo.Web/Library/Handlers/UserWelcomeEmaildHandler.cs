using MediatorPatternDemo.Web.Library.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPatternDemo.Web.Library.Handlers
{
    /// <summary>
    /// For more examples:
    /// https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples/PingedHandler.cs
    /// </summary>
    public class UserWelcomeEmaildHandler : INotificationHandler<UserCreated>
    {
        private readonly ILogger<UserQueryHandler> logger;

        public UserWelcomeEmaildHandler(ILogger<UserQueryHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Invoked {name} to handle {eventname} event.", nameof(UserWelcomeEmaildHandler), nameof(UserCreated));

            logger.LogInformation("We are sending out an email welcoming the new user {name} ({email}).", notification.Name, notification.Email);
            
            return Task.CompletedTask;
        }
    }
}
