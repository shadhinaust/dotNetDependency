using RestApi.Model;
using RestApi.Model.Map;
using System.Data.Entity;

namespace RestApi.Context
{
    public class RestApiContext : DbContext
    {
        public DbSet<Role> Role { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<GroupRole> GroupRole { get; set; }

        public RestApiContext() : base("sqlserver")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new SessionMap());
            modelBuilder.Configurations.Add(new LoginHistoryMap());
            modelBuilder.Configurations.Add(new UserGroupMap());
            modelBuilder.Configurations.Add(new GroupRoleMap());
        }
    }
}