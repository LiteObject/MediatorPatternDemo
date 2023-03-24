namespace MediatorPatternDemo.Web.Library.Attributes
{
    /// <summary>
    /// Applies a retry policy on the MediatR request.
    /// Apply this attribute to the MediatR <see cref="IRequest"/> class (not on the handler).
    /// 
    /// Original: https://gist.github.com/henkmollema/ba21bb90c35580a7189e77624d9ed8d1
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RetryPolicyAttribute : Attribute
    {
        private int _retryCount;
        private int _sleepDuration;

        public RetryPolicyAttribute(int retryCount = 3, int sleepDuration = 500)
        {
            RetryCount = retryCount;
            SleepDuration = sleepDuration;
        }

        /// <summary>
        /// Gets or sets the amount of times to retry the execution.
        /// Each retry the sleep duration is incremented by <see cref="SleepDuration"/>.
        /// Defaults to 3 times.
        /// </summary>
        public int RetryCount
        {
            get => _retryCount;
            internal set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Retry count must be higher than 1.", nameof(value));
                }

                _retryCount = value;
            }
        }
        /// <summary>
        /// Gets or sets the sleep duration in milliseconds.
        /// Each retry the sleep duration gets incremented by this value.
        /// Defaults to 500 milliseconds.
        /// </summary>
        public int SleepDuration
        {
            get => _sleepDuration;
            internal set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Sleep duration must be higher than 1ms.", nameof(value));
                }

                _sleepDuration = value;
            }
        }
    }
}
