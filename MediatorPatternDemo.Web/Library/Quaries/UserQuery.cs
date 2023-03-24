using MediatorPatternDemo.Web.Entities;

using MediatR;

namespace MediatorPatternDemo.Web.Library.Quaries
{
    public class UserQuery : IRequest<User>, IRequest<IList<User>>
    {
        public int? Id { get; set; }

        public string? Name { get; set; }
    }
}