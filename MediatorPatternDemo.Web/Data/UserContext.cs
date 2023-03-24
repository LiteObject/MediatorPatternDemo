using MediatorPatternDemo.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediatorPatternDemo.Web.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //_ = modelBuilder.Entity<User>().HasData(
            //    new User { Id = 1, Name = "User 1", Email = "user1@test.com" },
            //    new User { Id = 2, Name = "User 2", Email = "user2@test.com" },
            //    new User { Id = 3, Name = "User 3", Email = "user3@test.com" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
