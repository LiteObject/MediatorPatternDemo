namespace MediatorPatternDemo.Web.Library.Handlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatorPatternDemo.Web.Data;
    using MediatorPatternDemo.Web.Entities;
    using MediatorPatternDemo.Web.Library.Commands;

    using MediatR;

    using Microsoft.Extensions.Logging;

    using Newtonsoft.Json;

    /// <summary>
    /// The create user command handler.
    /// </summary>
    public class UserCommandHandler : 
        IRequestHandler<CreateUserCommand, User>,
        IRequestHandler<UpdateUserCommand, User>
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly UserContext context;

        /// <summary>
        /// The logger.
        /// </summary>
        private readonly ILogger<UserQueryHandler> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCommandHandler"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="logger">
        /// The logger.
        /// </param>
        public UserCommandHandler(UserContext context, ILogger<UserQueryHandler> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            this.logger.LogDebug($"Request Command: {JsonConvert.SerializeObject(command)}\n");

            var user = new User()
                           {
                               Name = command.Name,
                               Email = command.Email
                           };

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync(cancellationToken);

            return user;
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<User> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            this.logger.LogDebug($"Request Command: {JsonConvert.SerializeObject(command)}\n");

            User user = this.context.Users.FirstOrDefault(u => u.Id == command.Id);

            if (user is null)
            {
                return await Task.FromResult<User>(null);
            }

            user.Name = command.Name;
            user.Email = command.Email;

            // this.context.Users.Update(user);
            await this.context.SaveChangesAsync(cancellationToken);

            return user;
        }
    }
}
