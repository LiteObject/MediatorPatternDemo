using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MediatorPatternDemo.Web.Library.Events
{
    /// <summary>
    /// For more examples:
    /// https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples/PingedHandler.cs
    /// </summary>
    public class UserCreated : INotification
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
