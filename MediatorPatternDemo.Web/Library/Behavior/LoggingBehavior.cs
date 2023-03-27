using MediatR;
using System.Reflection;

namespace MediatorPatternDemo.Web.Library.Behavior
{
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
        // private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior()
        {
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Request
            Console.WriteLine("Pipeline behaviors were explicitly design for requests, NOT for notifications.");
            Console.WriteLine($"Handling {typeof(TRequest).Name}");

            Type myType = request.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            foreach (PropertyInfo prop in props)
            {
                object? propValue = prop.GetValue(request, null);
                Console.WriteLine($" - {prop.Name} : {propValue}");
            }

            TResponse? response = await next();

            // Response
            Console.WriteLine($"Handled \"{myType.Name}\". Response Type: {typeof(TResponse).Name}");
            return response;
        }
    }
}
