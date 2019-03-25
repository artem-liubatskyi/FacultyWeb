using Faculty.Data.Authentication_Models;
using Microsoft.EntityFrameworkCore;
using Faculty.Data.EntityConfigurations;

namespace Faculty.Data
{
    public class AuthenticationContext: DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options)
           : base(options)
        {
            //Database.EnsureCreated();
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
