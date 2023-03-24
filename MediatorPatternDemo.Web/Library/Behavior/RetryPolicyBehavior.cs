using MediatorPatternDemo.Web.Library.Attributes;
using MediatR;
using Polly;
using System.Reflection;

namespace MediatorPatternDemo.Web.Library.Behavior
{
    /// <summary>
    /// Wraps request handler execution of requests decorated with the <see cref="RetryPolicyAttribute"/>
    /// inside a policy to handle transient failures and retry the execution.
    /// 
    /// Original: https://gist.github.com/henkmollema/ba21bb90c35580a7189e77624d9ed8d1
    /// </summary>
    public class RetryPolicyBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        // private readonly ILogger<RetryPolicyBehavior<TRequest, TResponse>> _logger;

        public RetryPolicyBehavior()
        {
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            RetryPolicyAttribute? retryAttr = typeof(TRequest).GetCustomAttribute<RetryPolicyAttribute>();

            if (retryAttr == null)
            {
                Console.WriteLine($"There's no retry policy attached to {typeof(TRequest).Name}");
                return await next();
            }

            Console.WriteLine($"RetryCount: {retryAttr.RetryCount}, SleepDuration {retryAttr.SleepDuration}");

            // TODO: Add fallback policy

            return await Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    retryAttr.RetryCount,
                    i => TimeSpan.FromMilliseconds(i * retryAttr.SleepDuration),
                    (ex, ts, _) => Console.Error.WriteLine($"Failed to execute handler for request {typeof(TRequest).Name}, retrying after {ts.TotalSeconds}s: {ex.Message}", ex))
                .ExecuteAsync(async () => await next());
        }
    }
}
