using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}