using System.Data.Entity;

namespace RestApi.Model
{
    public class RestApiContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}