﻿using MediatorPatternDemo.Web.Library.Attributes;
using MediatR;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

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
        private readonly ILogger<RetryPolicyBehavior<TRequest, TResponse>> _logger;

        public RetryPolicyBehavior(ILogger<RetryPolicyBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var retryAttr = typeof(TRequest).GetCustomAttribute<RetryPolicyAttribute>();

            if (retryAttr == null)
            {
                _logger.LogDebug("There's no retry policy attached to {name}", typeof(TRequest).Name);
                return await next();
            }

            _logger.LogDebug("RetryCount: {count}, SleepDuration {duration}", retryAttr.RetryCount, retryAttr.SleepDuration);

            // TODO: Add fallback policy

            return await Policy
                .Handle<Exception>()
                .WaitAndRetryAsync(
                    retryAttr.RetryCount,
                    i => TimeSpan.FromMilliseconds(i * retryAttr.SleepDuration),
                    (ex, ts, _) => _logger.LogWarning(ex, "Failed to execute handler for request {Request}, retrying after {RetryTimeSpan}s: {ExceptionMessage}", typeof(TRequest).Name, ts.TotalSeconds, ex.Message))
                .ExecuteAsync(async () => await next());
        }
    }
}
