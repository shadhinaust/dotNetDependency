namespace RestApi.Model
{
    public class UserRole
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public short RoleId { get; set; }
        public Role Role { get; set; }

        public Auditor Auditor { get; set; }
    }
}