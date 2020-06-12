
using Microsoft.Ajax.Utilities;
using RestApi.Context;
using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RestApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public void Delete(long id)
        {
            using (var ctx = new EntityContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var user = ctx.User
                    .Where(usr => usr.Id == id)
                    .Include(usr => usr.UserGroups)
                    .Include(usr => usr.UserRoles)
                    .Include(usr => usr.Sessions)
                    .Include(usr => usr.LoginHistories)
                    .FirstOrDefault();
                ctx.User.Remove(user);
                ctx.SaveChanges();
            }
        }

        public List<User> GetAll()
        {
            using (var ctx = new EntityContext())
            {
                var users = ctx.User;
                var userGroups = ctx.UserGroup;
                var groups = ctx.Group;
                var groupRoles = ctx.GroupRole;
                var roles = ctx.Role;

/*                var joinQuery = from u in users
                               join ug in userGroups on u.Id equals ug.UserId
                               join g in groups on ug.GroupId equals g.Id
                               join gr in groupRoles on g.Id equals gr.GroupId
                               join r in roles on gr.RoleId equals r.Id
                               select new UserDto() { Name = u.Name, Email = u.Email, Status = u.Status };

                var joinQueryData = joinQuery.ToList();*/


/*                var fluentSyntex = users
                    .Join(userGroups,
                        u => u.Id,
                        ug => ug.UserId,
                        (u, ug) => new { u, u.Name, u.Email, ug.GroupId })
                    .Join(groups,
                        ug => ug.GroupId,
                        g => g.Id,
                        (ug, g) => new { g, g.Id, g.Name })
                    .Join(groupRoles,
                        g => g.Id,
                        gr => gr.GroupId,
                        (g, gr) => new { gr.RoleId })
                    .Join(roles,
                        gr => gr.RoleId,
                        r => r.Id,
                        (gr, r) => new { r, r.Name });

                var fluentSyntexData = fluentSyntex.ToList();*/

/*                var firstQuery = users.Include(user => user.UserGroups).ToList();
                var firstUsers = new List<User>();
                firstQuery.ForEach(user =>
                {
                    var allGroups = new HashSet<Group>();
                    user.UserGroups.ForEach(userGroup =>
                    {
                        allGroups.Add(groups
                            .Where(group => group.Id == userGroup.GroupId)
                            .Include(group => group.GroupRoles)
                            .SingleOrDefault());
                    });
                    user.Groups = allGroups;

                    var allRoles = new HashSet<Role>();
                    allGroups.ForEach(group =>
                    {
                        group.GroupRoles.ForEach(groupRole =>
                        {
                            allRoles.Add(roles
                                .Where(role => role.Id == groupRole.RoleId)
                                .SingleOrDefault());
                        });
                    });
                    user.Roles = allRoles;

                    firstUsers.Add(user);
                });*/

                /*var secondQuery = users
                    .Include(user => user.UserGroups)
                    .Include(user => user.Sessions)
                    .OrderBy(user => user.Id)
                    .Skip(0)
                    .Take(5)
                    .ToList();

                var secondUsers = new List<User>();
                secondQuery.ForEach(user =>
                {
                    var allGroups = new HashSet<Group>();
                    user.UserGroups
                        .Select(userGroup => userGroup.GroupId)
                        .ToHashSet()
                        .ForEach(groupId => 
                        {
                            allGroups.Add(groups
                                .Include(group => group.GroupRoles)
                                .Where(group => group.Id == groupId)
                                .FirstOrDefault());
                        });
                    user.Groups = allGroups;

                    var allRoles = new HashSet<Role>();
                    allGroups.ForEach(group =>
                    {
                        group.GroupRoles
                        .Select(groupRole => groupRole.RoleId)
                        .ToHashSet()
                        .ForEach(roleId => 
                        {
                            allRoles.Add(roles.Find(roleId));
                        });
                    });
                    user.Roles = allRoles;

                    secondUsers.Add(user);
                });*/

                return ctx.User.ToList();
            }
        }

        public List<User> GetAll(Group group)
        {
            using(var ctx = new EntityContext())
            {
                ctx.Database.Log = Console.Write;

                var users = ctx.User;
                var userGroups = ctx.UserGroup;
                var groups = ctx.Group;

                // 1st
/*                var uGrps = groups
                    .Include(grp => grp.UserGroups)
                    .Where(grp => grp.Id == group.Id)
                    .FirstOrDefault()
                    .UserGroups
                    .Select(ug => ug.UserId)
                    .ToList();

                var allUsers = users.Where(user => uGrps
                    .Contains(user.Id))
                    .ToList();*/

                // 2nd 
                var allUsers_2 = users.Where(user => userGroups
                    .Where(userGroup => userGroup.GroupId == group.Id)
                    .Select(userGroup => userGroup.UserId)
                    .ToList()
                    .Contains(user.Id))
                    .ToList();

                return allUsers_2;
            }
        }

        public User GetOne(long id)
        {
            using(var ctx = new EntityContext())
            {
                ctx.Database.Log = Console.WriteLine;
                var user = ctx.User
                    .Where(usr => usr.Id == id)
                    .Include(usr => usr.UserGroups)
                    .FirstOrDefault<User>();
                return user;
            }
        }

        public User Save(User user)
        {
            using (var ctx = new EntityContext())
            {
                ctx.Database.Log = Console.WriteLine;
                user.UserGroups.ForEach(userGroup =>
                {
                    ctx.UserGroup.Add(userGroup);
                });
                ctx.User.Add(user);
                ctx.SaveChanges();
                return user;
            }
        }

        public User Update(User user)
        {
            using (var ctx = new EntityContext())
            {
                ctx.Database.Log = Console.WriteLine;

                user.UserGroups.ForEach(userGroup =>
                {
                    ctx.UserGroup.AddOrUpdate(userGroup);
                });

                /*                ctx.Entry(user).State = EntityState.Modified;
                                user.UserGroups.ForEach(ug =>
                                {
                                    ctx.Entry(ug).State = EntityState.Modified;
                                });*/

                ctx.User.AddOrUpdate(user);

                ctx.SaveChanges();
                return user;
            }
        }
    }
}