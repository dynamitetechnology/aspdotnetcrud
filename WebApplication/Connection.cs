using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class Connection
    {
        string constr = "data source=DESKTOP-OMO8SJB\\SQLEXPRESS; database=Users; integrated security=SSPI";
        public string Connect()
        {
            return constr;
        }
    }
}