namespace RestApi.Migrations
{
    using RestApi.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestApi.Model.RestApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestApi.Model.RestApiContext ctx)
        {
            Role role1 = new Role() { Id = 1, Name = "Master Admin", Description = "Master admin can perform all the task", Status = Status.Active.ToString() };
            Role role2 = new Role() { Id = 2, Name = "Admin", Description = "Admin can perform all the task but less the master", Status = Status.Active.ToString() };
            Role role3 = new Role() { Id = 3, Name = "Manager", Description = "Manager can perform all the managerial task", Status = Status.Active.ToString() };

            Group group1 = new Group() { Id = 1, Name = "Admin", Description = "Admin can perform all the assign task", Status = Status.Active.ToString() };
            Group group2 = new Group() { Id = 2, Name = "Editor", Description = "Editor can perform all the assign task", Status = Status.Active.ToString() };
            Group group3 = new Group() { Id = 3, Name = "Operation", Description = "Operation can perform all the assign task", Status = Status.Active.ToString() };

            User user1 = new User() { Id = 1, Name = "Shain", Email = "shain@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User user2 = new User() { Id = 2, Name = "Shadhin", Email = "shadhin@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User user3 = new User() { Id = 3, Name = "Fuad", Email = "fuad@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User user4 = new User() { Id = 4, Name = "Naim", Email = "naim@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User user5 = new User() { Id = 5, Name = "Shahid", Email = "shahid@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User user6 = new User() { Id = 6, Name = "Kibria", Email = "kibria@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User user7 = new User() { Id = 7, Name = "Chowdhury", Email = "chowdhury@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User user8 = new User() { Id = 8, Name = "Golam", Email = "golam@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };
            User user9 = new User() { Id = 9, Name = "Ahmed", Email = "ahmed@asiatel.com.sg", Password = "password", ResetCode = 12345, LoginAttempt = 0, Status = Status.Active.ToString() };

            role1.Users = new List<User>() { user1, user2, user3, user4, user5 };
            role2.Users = new List<User>() { user1, user2, user3, user4, user5, user6, user7 };
            role3.Users = new List<User>() { user1, user2, user3, user4, user6, user7, user8, user9 };

            user1.Roles = new List<Role>() { role1, role2, role3 };
            user2.Roles = new List<Role>() { role1, role2, role3 };
            user3.Roles = new List<Role>() { role1, role2, role3 };
            user4.Roles = new List<Role>() { role1, role2, role3 };
            user5.Roles = new List<Role>() { role1, role2 };
            user6.Roles = new List<Role>() { role2, role3 };
            user7.Roles = new List<Role>() { role2, role3 };
            user8.Roles = new List<Role>() { role3 };
            user9.Roles = new List<Role>() { role3 };


            group1.Users = new List<User>() { user1, user2, user3, user4, user5, user6 };
            group2.Users = new List<User>() { user1, user2, user3, user4, user5, user6, user7 };
            group3.Users = new List<User>() { user1, user2, user3, user4, user7, user8, user9 };

            user1.Groups = new List<Group>() { group1, group2, group3 };
            user2.Groups = new List<Group>() { group1, group2, group3 };
            user3.Groups = new List<Group>() { group1, group2, group3 };
            user4.Groups = new List<Group>() { group1, group2, group3 };
            user5.Groups = new List<Group>() { group1, group2 };
            user6.Groups = new List<Group>() { group1, group2 };
            user7.Groups = new List<Group>() { group2, group3 };
            user8.Groups = new List<Group>() { group3 };
            user9.Groups = new List<Group>() { group3 };

            ctx.Role.AddOrUpdate(role => role.Id, role1);
            ctx.Role.AddOrUpdate(role => role.Id, role2);
            ctx.Role.AddOrUpdate(role => role.Id, role3);

            ctx.Group.AddOrUpdate(group => group.Id, group1);
            ctx.Group.AddOrUpdate(group => group.Id, group2);
            ctx.Group.AddOrUpdate(group => group.Id, group3);

            ctx.User.AddOrUpdate(user => user.Id, user1);
            ctx.User.AddOrUpdate(user => user.Id, user2);
            ctx.User.AddOrUpdate(user => user.Id, user3);
            ctx.User.AddOrUpdate(user => user.Id, user4);
            ctx.User.AddOrUpdate(user => user.Id, user5);
            ctx.User.AddOrUpdate(user => user.Id, user6);
            ctx.User.AddOrUpdate(user => user.Id, user7);
            ctx.User.AddOrUpdate(user => user.Id, user8);
            ctx.User.AddOrUpdate(user => user.Id, user9);

            ctx.SaveChanges();
        }
    }
}
