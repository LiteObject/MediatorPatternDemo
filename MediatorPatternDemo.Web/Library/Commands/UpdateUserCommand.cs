namespace MediatorPatternDemo.Web.Library.Commands
{
    using System.ComponentModel.DataAnnotations;

    using MediatorPatternDemo.Web.Entities;

    using MediatR;

    /// <summary>
    /// The update user command.
    /// </summary>
    public class UpdateUserCommand : IRequest<User>
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid Id value")]
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
