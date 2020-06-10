using RestApi.Dto;
using RestApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Utils
{
    public class UserConverter
    {
        public static UserDto ToUserDto(User user)
        {
            return new UserDto() { Name= user.Name, Email = user.Email, Status=user.Status };
        }

        public static User ToUser(UserDto userDto)
        {
            return new User() { };
        }
    }
}