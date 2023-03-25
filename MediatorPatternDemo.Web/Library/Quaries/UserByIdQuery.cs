using MediatorPatternDemo.Web.Entities;
using MediatR;

namespace MediatorPatternDemo.Web.Library.Quaries
{
    public class UserByIdQuery : IRequest<User>
    {
        public int Id { get; set; }
    }
}
