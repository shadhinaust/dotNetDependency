using RestApi.Dto;
using System.Collections.Generic;

namespace RestApi.Service.Facade
{
    public interface IUserServiceFacade
    {
        List<UserDto> GetAllUsersByGroupId(short id);
    }
}
