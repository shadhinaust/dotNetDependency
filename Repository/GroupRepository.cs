using RestApi.Context;
using RestApi.Model;
using System;
using System.Collections.Generic;

namespace RestApi.Repository
{
    public class GroupRepository : IGroupRepository
    {
        public void Delete(short id)
        {
            throw new NotImplementedException();
        }

        public List<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group GetOne(short id)
        {
            using(var ctx = new EntityContext())
            {
                return ctx.Group.Find(id);
            }
        }

        public Group Save(Group group)
        {
            throw new NotImplementedException();
        }

        public Group Update(Group group)
        {
            throw new NotImplementedException();
        }
    }
}