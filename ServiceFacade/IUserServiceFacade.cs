using RestApi.Model;
using System.Collections.Generic;

namespace RestApi.ServiceFacade
{
    public interface IUserServiceFacade
    {
        List<User> GetAllUsersByGroupId(short id);
    }
}
