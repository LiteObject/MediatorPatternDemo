namespace MediatorPatternDemo.Web.Library.Behaviour
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// NOTE: Pipeline behaviors were explicitly design for requests, NOT for notifications.
    /// "If you want something like a pipeline for notifications, you can override the PublishCore method in the Mediator class, 
    /// or you can register decorators for notification handlers in your container of choice." - jbogard
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Request
            _logger.LogTrace("Pipeline behaviors were explicitly design for requests, NOT for notifications.");
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");
            Type myType = request.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(request, null);
                _logger.LogInformation(" - {Property} : {@Value}", prop.Name, propValue);
            }

            var response = await next();

            // Response
            _logger.LogInformation($"Handled \"{myType.Name}\". Response Type: {typeof(TResponse).Name}");
            return response;
        }
    }
}
