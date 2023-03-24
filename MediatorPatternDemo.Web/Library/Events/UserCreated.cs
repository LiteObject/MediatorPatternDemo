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
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
