using RestApi.Context;
using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;

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
            using (var ctx = new EntityContext())
            {
                return ctx.Group.ToList();
            }
        }

        public List<Group> GetAll(List<short> ids)
        {
            using (var ctx = new EntityContext())
            {
                return ctx.Group
                    .Where(group => ids.Contains(group.Id))
                    .Distinct()
                    .ToList();
            }
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