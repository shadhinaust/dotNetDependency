using System.Data.Entity;

namespace RestApi.Model
{
    public class RestApiContext : DbContext
    {
        public DbSet<Role> Role { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<Session> Session { get; set; }

        public RestApiContext() : base("sqlserver")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
/*            modelBuilder.Entity<Student>()
                    .Property(s => s.CreatedDate)
                    .HasDefaultValueSql("GETDATE()");*/
        }
    }
}