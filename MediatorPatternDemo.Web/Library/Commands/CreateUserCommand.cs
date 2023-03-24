using MediatorPatternDemo.Web.Entities;
using MediatorPatternDemo.Web.Library.Attributes;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MediatorPatternDemo.Web.Library.Commands
{
    [RetryPolicy(2, 200)]
    public class CreateUserCommand : IRequest<User>
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
