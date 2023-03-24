namespace MediatorPatternDemo.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using MediatorPatternDemo.Web.Entities;
    using MediatorPatternDemo.Web.Library.Commands;
    using MediatorPatternDemo.Web.Library.Events;
    using MediatorPatternDemo.Web.Library.Quaries;

    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(
             Summary = "Retrieve a list of user",
             Description = "Retrieve a list of users",
             Tags = new[] { "users" })
        ]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<User>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll([FromQuery] UserQuery query = null)
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
        [SwaggerOperation(
             Summary = "Retrieve a user by Id",
             Description = "Retrieve a user by Id",
             Tags = new[] { "user" })
        ]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            //if (!ModelState.IsValid)
            //{
            //    return this.BadRequest(this.ModelState);
            //}

            User user = await this._mediator.Send(command);
            await this._mediator.Publish<UserCreated>(new UserCreated() { 
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            });

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
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody] UpdateUserCommand command)
        {
            //if (!ModelState.IsValid)
            //{
            //    return this.BadRequest(this.ModelState);
            //}

            if (id != command.Id) 
            {
                return this.Problem(title: "Mismatched Ids", detail: $"Mismatched Ids", statusCode: (int)HttpStatusCode.BadRequest);
            }

            User user = await this._mediator.Send(command);

            if (user is null)
            {
                // return this.BadRequest($"User doesn't exist in the system. {JsonConvert.SerializeObject(command)}");
                return this.Problem(title: "User doesn't exist", detail: $"Unable to fund user in the system.", statusCode: (int)HttpStatusCode.BadRequest);
            }

            // return this.NoContent();
            return this.Accepted(user);
        }
    }
}