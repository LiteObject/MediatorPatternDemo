namespace MediatorPatternDemo.Web.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using MediatorPatternDemo.Web.Entities;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The user context.
    /// </summary>
    public class UserContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// The on model creating.
        /// </summary>
        /// <param name="modelBuilder">
        /// The model builder.
        /// </param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "User 1", Email = "user1@test.com" },
                new User { Id = 2, Name = "User 2", Email = "user2@test.com" },
                new User { Id = 3, Name = "User 3", Email = "user3@test.com" });
        }
    }
}
