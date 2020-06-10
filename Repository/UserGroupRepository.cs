using RestApi.Context;
using RestApi.Model;
using System;
using System.Collections.Generic;

namespace RestApi.Repository
{
    public class UserGroupRepository : IUserGroupRepository
    {
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<UserGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<UserGroup> GetAll(List<long> ids)
        {
            throw new NotImplementedException();
        }

        public UserGroup GetOne(long id)
        {
            throw new NotImplementedException();
        }

        public UserGroup Save(UserGroup userGroup)
        {
            using(var ctx = new EntityContext())
            {
                ctx.UserGroup.Add(userGroup);
                ctx.SaveChanges();
                return userGroup;
            }
        }

        public UserGroup Update(UserGroup userGroup)
        {
            throw new NotImplementedException();
        }
    }
}