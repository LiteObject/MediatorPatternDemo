using MediatorPatternDemo.Web.Library.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorPatternDemo.Web.Library.Handlers
{
    public class UserAccessSetupHandler : INotificationHandler<UserCreated>
    {
        private readonly ILogger<UserAccessSetupHandler> logger;

        public UserAccessSetupHandler(ILogger<UserAccessSetupHandler> logger)
        {
            this.logger = logger;
        }

        public Task Handle(UserCreated notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Invoked {name} to handle {eventname} event.", nameof(UserAccessSetupHandler), nameof(UserCreated));

            logger.LogInformation("We are setting up access for {name}", notification.Name);

            return Task.CompletedTask;
        }
    }
}
