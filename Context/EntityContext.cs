using Microsoft.Ajax.Utilities;
using RestApi.Model;
using RestApi.Model.Map;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestApi.Context
{
    public class EntityContext : DbContext
    {
        public DbSet<Role> Role { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<LoginHistory> LoginHistory { get; set; }
        public DbSet<Session> Session { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
        public DbSet<GroupRole> GroupRole { get; set; }

        public EntityContext() : base("sqlserver")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var auditor = modelBuilder.ComplexType<Auditor>();

            auditor.Property(aud => aud.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            auditor.Property(aud => aud.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("datetime")
                .IsRequired();

            auditor.Property(aud => aud.ModifiedBy)
                .HasColumnName("modified_by")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            auditor.Property(aud => aud.ModifiedAt)
                .HasColumnName("modified_at")
                .HasColumnType("datetime")
                .IsRequired();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new SessionMap());
            modelBuilder.Configurations.Add(new LoginHistoryMap());
            modelBuilder.Configurations.Add(new UserGroupMap());
            modelBuilder.Configurations.Add(new GroupRoleMap());
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is Auditor && (x.State == EntityState.Added || x.State == EntityState.Modified));
            var userName = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
                ? HttpContext.Current.User.Identity.Name
                : "Anonymous";
            var now = DateTime.Now;
            entities.ForEach(entity =>
            {
                if (entity.State == EntityState.Added)
                {
                    ((Auditor)entity.Entity).CreatedAt = now;
                    ((Auditor)entity.Entity).CreatedBy = userName;
                }
                ((Auditor)entity.Entity).ModifiedAt = now;
                ((Auditor)entity.Entity).ModifiedBy = userName;
            });
        }
    }
}