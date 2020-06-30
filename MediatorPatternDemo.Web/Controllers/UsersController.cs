namespace MediatorPatternDemo.Web.Controllers
{
    using System.Threading.Tasks;

    using MediatorPatternDemo.Web.Entities;
    using MediatorPatternDemo.Web.Library.Commands;
    using MediatorPatternDemo.Web.Library.Quaries;

    using MediatR;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    /// <summary>
    /// The users controller.
    /// More info: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<UsersController> logger;

        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="mediator">
        /// The mediator.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public UsersController(IMediator mediator, ILogger<UsersController> logger)
        {
            this.mediator = mediator;
            this.logger = logger;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] UserQuery query)
        {
            User user = await this.mediator.Send(query);

            if (user == null)
            {
                return this.NotFound(query);
            }

            this.logger.LogInformation($"{JsonConvert.SerializeObject(user)}");
            return this.Ok(user);
        }

        /// <summary>
        /// The post.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            User user = await this.mediator.Send(command);
            return this.Accepted(user);
        }
    }
}