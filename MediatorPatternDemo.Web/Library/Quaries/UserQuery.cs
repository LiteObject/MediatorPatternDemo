using MediatorPatternDemo.Web.Entities;

using MediatR;

namespace MediatorPatternDemo.Web.Library.Quaries
{
    public class UserQuery : IRequest<User>, IRequest<IList<User>>
    {
        public string? Email { get; set; }

        public string? Name { get; set; }
    }
}