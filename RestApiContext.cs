
using System.Configuration;
using System.Data.Entity;

namespace RestApi.Model
{
    public class RestApiContext : DbContext

    {
        public RestApiContext() : base("sqlserver")
        {

        }

        // ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}