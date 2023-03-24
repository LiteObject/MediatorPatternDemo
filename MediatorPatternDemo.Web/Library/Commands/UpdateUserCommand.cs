using MediatorPatternDemo.Web.Entities;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace MediatorPatternDemo.Web.Library.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid user Id value")]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
