namespace MediatorPatternDemo.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
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
        private readonly ILogger<UsersController> _logger;

        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator _mediator;

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
            this._mediator = mediator;
            this._logger = logger;
        }

        /// <summary>
        /// The get all.
        /// By default, route parameters cannot be optional in OpenAPI/Swagger.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromRoute] UserQuery query)
        {
            // By default, route parameters cannot be optional in OpenAPI/Swagger.
            IList<User> users = await this._mediator.Send<IList<User>>(query);

            if (users == null)
            {
                return this.NotFound();
            }
            
            this._logger.LogInformation($"{JsonConvert.SerializeObject(users)}");
            return this.Ok(users);
        }

        /// <summary>
        /// The get by id.
        /// By default, route parameters cannot be optional in OpenAPI/Swagger.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // By default, route parameters cannot be optional in OpenAPI/Swagger.
            var query = new UserQuery() { Id = id };
            IList<User> users = await this._mediator.Send<IList<User>>(query);

            if (users == null)
            {
                return this.NotFound(query);
            }

            User user = users.FirstOrDefault();

            this._logger.LogInformation($"{JsonConvert.SerializeObject(user)}");
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

            User user = await this._mediator.Send(command);

            return this.CreatedAtAction(nameof(this.Get), new { id = user.Id }, user);
        }

        /// <summary>
        /// The put.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            User user = await this._mediator.Send(command);

            if (user is null)
            {
                return this.BadRequest($"User doesn't exist in the system. {JsonConvert.SerializeObject(command)}");
            }

            // return this.NoContent();
            return this.Accepted(user);
        }
    }
}