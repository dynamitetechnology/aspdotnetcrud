using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class _Default : Page
    {
        public static DataTable TableData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAllData();
            }
        }

        private void GetAllData() //Get all the data and bind it in HTLM Table     
        {
             
        Connection cons = new Connection();
            using (var con = new SqlConnection(cons.Connect()))
            {
                const string query = "select id, fname, lname from testme order by id desc";
                using (var cmd = new SqlCommand(query, con))
                {
                    using (var sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (TableData)
                        {
                            TableData.Clear();
                            sda.Fill(TableData);
                        }
                    }
                }
            }
        }


        protected void insertData(object sender, EventArgs e)
        {
            Connection cons = new Connection();
            SqlConnection con = null;
            try
            {
                string fname = fName.Text;
                string lname = lName.Text;
                string SaveLocation = "";
                string newlocation;
                if ((FileUpLoad1.PostedFile != null) && (FileUpLoad1.PostedFile.ContentLength > 0))
                {
                    string fn = System.IO.Path.GetFileName(FileUpLoad1.PostedFile.FileName);
                    SaveLocation = Server.MapPath("Uploads") + "\\" + fn;
                    newlocation = "\\"+"Uploads" + "\\" + fn;
                    FileUpLoad1.PostedFile.SaveAs(SaveLocation);

                }
                //  FileUploadStatus.Text = "The file has been uploaded.";
                // Creating Connection  
                con = new SqlConnection(cons.Connect());
                // writing sql query  
                string sql = "insert into testme(fname, lname) values ('" + fname + "','" + lname + "')";

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