using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class edit : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack)
            {
                GetAllData(id);
            }
        }

        private void GetAllData(int id) //Get all the data and bind it in HTLM Table     
        {

            Connection cons = new Connection();
            using (var con = new SqlConnection(cons.Connect()))
            {
                string query = "select id, fname, lname from testme where id = '" + id + "' order by id desc";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
        }

        protected void updateData(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;

            string fname = (item.FindControl("updateFname") as TextBox).Text;
            string lname = (item.FindControl("updateLname") as TextBox).Text;
            int id = Convert.ToInt32(Request.QueryString["id"]);
            Connection cons = new Connection();

            SqlConnection con = null;

            try
            {
               
                // Creating Connection  
                con = new SqlConnection(cons.Connect());
                // writing sql query  
                string sql = "update testme set fname  = '"+ fname + "', lname = '"+lname+"' where id = '"+ id + "'";

                SqlCommand cm = new SqlCommand(sql, con);
                // Opening Connection  
                con.Open();
                int status = cm.ExecuteNonQuery();

                if (status > 0)
                {
                    Console.WriteLine("Success");
                    Response.Redirect("Default");
                }
                else
                {
                    Console.WriteLine("Fail");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}