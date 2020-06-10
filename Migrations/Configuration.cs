namespace RestApi.Migrations
{
    using RestApi.Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RestApi.Context.EntityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestApi.Context.EntityContext ctx)
        {
            // Roles
            Role Role_1 = new Role() { Id = 1, Name = "Master Admin", Description = "Master admin can perform all the task", Status = Status.Active.ToString() };
            Role Role_2 = new Role() { Id = 2, Name = "Admin", Description = "Admin can perform all the task but less the master", Status = Status.Active.ToString() };
            Role Role_3 = new Role() { Id = 3, Name = "Manager", Description = "Manager can perform all the managerial task", Status = Status.Active.ToString() };

            // Groups
            Group Group_1 = new Group() { Id = 1, Name = "Admin", Description = "Admin can perform all the assign task", Status = Status.Active.ToString() };
            Group Group_2 = new Group() { Id = 2, Name = "Editor", Description = "Editor can perform all the assign task", Status = Status.Active.ToString() };
            Group Group_3 = new Group() { Id = 3, Name = "Operation", Description = "Operation can perform all the assign task", Status = Status.Active.ToString() };

            // Users
            User User_1 = new User() { Id = 1, Name = "Shain", Email = "shain@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User User_2 = new User() { Id = 2, Name = "Shadhin", Email = "shadhin@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User User_3 = new User() { Id = 3, Name = "Fuad", Email = "fuad@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User User_4 = new User() { Id = 4, Name = "Naim", Email = "naim@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User User_5 = new User() { Id = 5, Name = "Shahid", Email = "shahid@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User User_6 = new User() { Id = 6, Name = "Kibria", Email = "kibria@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User User_7 = new User() { Id = 7, Name = "Chowdhury", Email = "chowdhury@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User User_8 = new User() { Id = 8, Name = "Golam", Email = "golam@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User User_9 = new User() { Id = 9, Name = "Ahmed", Email = "ahmed@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };

            // UserGroups
            UserGroup UserGroup_1 = new UserGroup() { Id = 1, UserId = 1, GroupId = 1 };
            UserGroup UserGroup_2 = new UserGroup() { Id = 2, UserId = 1, GroupId = 2 };
            UserGroup UserGroup_3 = new UserGroup() { Id = 3, UserId = 1, GroupId = 3 };

            UserGroup UserGroup_4 = new UserGroup() { Id = 4, UserId = 2, GroupId = 1 };
            UserGroup UserGroup_5 = new UserGroup() { Id = 5, UserId = 2, GroupId = 2 };
            UserGroup UserGroup_6 = new UserGroup() { Id = 6, UserId = 2, GroupId = 3 };

            UserGroup UserGroup_7 = new UserGroup() { Id = 7, UserId = 3, GroupId = 1 };
            UserGroup UserGroup_8 = new UserGroup() { Id = 8, UserId = 3, GroupId = 2 };
            UserGroup UserGroup_9 = new UserGroup() { Id = 9, UserId = 3, GroupId = 3 };

            UserGroup UserGroup_10 = new UserGroup() { Id = 10, UserId = 4, GroupId = 1 };
            UserGroup UserGroup_11 = new UserGroup() { Id = 11, UserId = 4, GroupId = 2 };
            UserGroup UserGroup_12 = new UserGroup() { Id = 12, UserId = 4, GroupId = 3 };

            UserGroup UserGroup_13 = new UserGroup() { Id = 13, UserId = 5, GroupId = 1 };
            UserGroup UserGroup_14 = new UserGroup() { Id = 14, UserId = 5, GroupId = 2 };

            UserGroup UserGroup_15 = new UserGroup() { Id = 15, UserId = 6, GroupId = 1 };
            UserGroup UserGroup_16 = new UserGroup() { Id = 16, UserId = 6, GroupId = 2 };

            UserGroup UserGroup_17 = new UserGroup() { Id = 17, UserId = 7, GroupId = 2 };
            UserGroup UserGroup_18 = new UserGroup() { Id = 18, UserId = 7, GroupId = 3 };

            UserGroup UserGroup_19 = new UserGroup() { Id = 19, UserId = 8, GroupId = 3 };

            UserGroup UserGroup_20 = new UserGroup() { Id = 20, UserId = 9, GroupId = 3 };

            // UserGroup Mapping
            User_1.UserGroups = new List<UserGroup>() { UserGroup_1, UserGroup_2, UserGroup_3 };
            User_2.UserGroups = new List<UserGroup>() { UserGroup_4, UserGroup_5, UserGroup_6 };
            User_3.UserGroups = new List<UserGroup>() { UserGroup_7, UserGroup_8, UserGroup_9 };
            User_4.UserGroups = new List<UserGroup>() { UserGroup_10, UserGroup_11, UserGroup_12 };
            User_5.UserGroups = new List<UserGroup>() { UserGroup_13, UserGroup_14 };
            User_6.UserGroups = new List<UserGroup>() { UserGroup_15, UserGroup_16 };
            User_7.UserGroups = new List<UserGroup>() { UserGroup_17, UserGroup_18 };
            User_8.UserGroups = new List<UserGroup>() { UserGroup_19 };
            User_9.UserGroups = new List<UserGroup>() { UserGroup_20 };

            Group_1.UserGroups = new List<UserGroup>() { UserGroup_1, UserGroup_4, UserGroup_7, UserGroup_10, UserGroup_13, UserGroup_15 };
            Group_1.UserGroups = new List<UserGroup>() { UserGroup_2, UserGroup_5, UserGroup_8, UserGroup_11, UserGroup_14, UserGroup_16, UserGroup_17 };
            Group_1.UserGroups = new List<UserGroup>() { UserGroup_3, UserGroup_6, UserGroup_9, UserGroup_12, UserGroup_19, UserGroup_20 };

            // GroupRoles
            GroupRole GroupRole_1 = new GroupRole() { Id = 1, GroupId = 1, RoleId = 1 };
            GroupRole GroupRole_2 = new GroupRole() { Id = 2, GroupId = 1, RoleId = 2 };
            GroupRole GroupRole_3 = new GroupRole() { Id = 3, GroupId = 1, RoleId = 3 };

            GroupRole GroupRole_4 = new GroupRole() { Id = 5, GroupId = 2, RoleId = 2 };
            GroupRole GroupRole_5 = new GroupRole() { Id = 6, GroupId = 2, RoleId = 3 };

            GroupRole GroupRole_6 = new GroupRole() { Id = 9, GroupId = 3, RoleId = 3 };

            // GroupRole Mapping
            Group_1.GroupRoles = new List<GroupRole>() { GroupRole_1, GroupRole_2, GroupRole_3 };
            Group_2.GroupRoles = new List<GroupRole>() { GroupRole_4, GroupRole_5 };
            Group_3.GroupRoles = new List<GroupRole>() { GroupRole_6 };

            Role_1.GroupRoles = new List<GroupRole>() { GroupRole_1 };
            Role_2.GroupRoles = new List<GroupRole>() { GroupRole_2, GroupRole_4 };
            Role_3.GroupRoles = new List<GroupRole>() { GroupRole_3, GroupRole_5, GroupRole_6 };


            ctx.Role.AddOrUpdate(role => role.Id, Role_1);
            ctx.Role.AddOrUpdate(role => role.Id, Role_2);
            ctx.Role.AddOrUpdate(role => role.Id, Role_3);

            ctx.Group.AddOrUpdate(group => group.Id, Group_1);
            ctx.Group.AddOrUpdate(group => group.Id, Group_2);
            ctx.Group.AddOrUpdate(group => group.Id, Group_3);

            ctx.User.AddOrUpdate(user => user.Id, User_1);
            ctx.User.AddOrUpdate(user => user.Id, User_2);
            ctx.User.AddOrUpdate(user => user.Id, User_3);
            ctx.User.AddOrUpdate(user => user.Id, User_4);
            ctx.User.AddOrUpdate(user => user.Id, User_5);
            ctx.User.AddOrUpdate(user => user.Id, User_6);
            ctx.User.AddOrUpdate(user => user.Id, User_7);
            ctx.User.AddOrUpdate(user => user.Id, User_8);
            ctx.User.AddOrUpdate(user => user.Id, User_9);


            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_1);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_2);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_3);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_4);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_5);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_6);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_7);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_8);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_9);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_10);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_11);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_12);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_13);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_14);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_15);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_16);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_17);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_18);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_19);
            ctx.UserGroup.AddOrUpdate(userGroup => userGroup.Id, UserGroup_20);

            ctx.GroupRole.AddOrUpdate(groupRole => groupRole.Id, GroupRole_1);
            ctx.GroupRole.AddOrUpdate(groupRole => groupRole.Id, GroupRole_2);
            ctx.GroupRole.AddOrUpdate(groupRole => groupRole.Id, GroupRole_3);
            ctx.GroupRole.AddOrUpdate(groupRole => groupRole.Id, GroupRole_4);
            ctx.GroupRole.AddOrUpdate(groupRole => groupRole.Id, GroupRole_5);
            ctx.GroupRole.AddOrUpdate(groupRole => groupRole.Id, GroupRole_6);

            ctx.SaveChanges();
        }
    }
}
