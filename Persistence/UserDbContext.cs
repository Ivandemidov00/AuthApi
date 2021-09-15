using System.Threading.Tasks;
using Application.Interfases;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.ConfigDomain;

namespace Persistence
{
    public class UserDbContext:DbContext,IUserDBContext
    {
        public DbSet<User> Users { get; set; }
        
            public UserDbContext(DbContextOptions<UserDbContext> options)
                : base(options) { }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.ApplyConfiguration(new UserConfiguration());
                base.OnModelCreating(builder);
            }
    }
}