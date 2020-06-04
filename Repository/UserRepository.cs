using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RestApi.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly static Dictionary<long, User> _users = new Dictionary<long, User>();
        public void Delete(long id)
        {
            var ctx = new RestApiContext();
            ctx.Database.Log = Console.WriteLine;
            var user = ctx.User.Find(id);
            ctx.User.Remove(user);
            ctx.SaveChanges();
            ctx.Dispose();
        }

        public List<User> GetAll()
        {
            var ctx = new RestApiContext();
            ctx.Database.Log = Console.WriteLine;
            var users = ctx.User.Include(usr=>usr.Roles).ToList();
            ctx.Dispose();
            return users;
        }

        public User GetOne(long id)
        {
            var ctx = new RestApiContext();
            ctx.Database.Log = Console.WriteLine;
            var user = ctx.User
                .Where(usr => usr.Id == id)
                .FirstOrDefault();
            ctx.Entry(user).Collection(usr => user.Roles).Load();
            ctx.Dispose();
            return user;
        }

        public User Save(User user)
        {
            var ctx = new RestApiContext();
            ctx.Database.Log = Console.WriteLine;
            ctx.User.Add(user);
            ctx.SaveChanges();
            ctx.Dispose();
            return user;
        }

        public User Update(User user)
        {
            var ctx = new RestApiContext();
            ctx.Database.Log = Console.WriteLine;
            ctx.User.Attach(user);
            ctx.Entry(user).State = EntityState.Modified;
            ctx.SaveChanges();
            ctx.Dispose();
            return user;
        }
    }
}