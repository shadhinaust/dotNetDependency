using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Repository
{
    public class UserRepository : IUserRepository
    {
        readonly static Dictionary<long, User> _users = new Dictionary<long, User>();
        public void Delete(long id)
        {
            _users.Remove(id);
        }

        public List<User> GetAll()
        {
            return _users.Select(user => user.Value).ToList();
        }

        public User GetOne(long id)
        {
            return _users.FirstOrDefault(user => user.Key == id).Value;
        }

        public User Save(User user)
        {
            List<User> users = GetAll();
            long id = users.Any() ? users.Max(usr => usr.Id) + 1 : 1;
            user.Id = id;
            _users.Add(id, user);
            return user;
        }

        public User Update(User user)
        {
            if(GetOne(user.Id) == null)
            {
                return null;
            }
            _users[user.Id] = user;
            return user;
        }
    }
}