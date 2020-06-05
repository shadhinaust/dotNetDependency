using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestApi.Model
{
    public enum Status
    {
        Active = 1000,
        Hold = 900,
        Suspended = 500,
        Inactive = 0
    }
}