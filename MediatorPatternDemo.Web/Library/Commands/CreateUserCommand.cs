namespace MediatorPatternDemo.Web.Library.Commands
{
    using System.ComponentModel.DataAnnotations;

    using MediatorPatternDemo.Web.Entities;
    using MediatorPatternDemo.Web.Library.Attributes;
    using MediatR;

    /// <summary>
    /// The command.
    /// </summary>
    [RetryPolicy(2, 200)]
    public class CreateUserCommand : IRequest<User>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
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
