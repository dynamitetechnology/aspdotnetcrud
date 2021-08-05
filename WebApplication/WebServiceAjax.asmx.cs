using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebApplication
{
    /// <summary>
    /// Summary description for WebServiceAjax
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebServiceAjax : System.Web.Services.WebService
    {

        [WebMethod]
        public string deleteRecord(string id)
        {
            //Connection cons = new Connection();
            //SqlConnection con = new SqlConnection(cons.Connect());
            //string query = "delete  from testme where  id = '"+myUserName+"'";
            //SqlCommand cm = new SqlCommand(query, con);
            //// Opening Connection  
            //con.Open();
            //int status = cm.ExecuteNonQuery();
            return "Response From Web Service "+ id;
            //con.Close();
        }
    }
}
