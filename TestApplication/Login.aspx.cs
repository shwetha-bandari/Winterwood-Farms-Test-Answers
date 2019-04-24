using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TestApplication
{
    /// <summary>
    /// login class
    /// </summary>
    public partial class Login : System.Web.UI.Page
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// Method for login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            var username = txtuser.Text;
            var password = txtpwd.Text;
            con.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sagar\OneDrive\Desktop\.net material\TestApplication\Database\TestDatabase.mdf;Integrated Security=True;Connect Timeout=30";
            if(con.State == ConnectionState.Closed)
            con.Open();
            cmd.CommandText = "select UserId,Username,Password from [User] where Username ='" + username + "' and Password='" + password + "'";
            cmd.Connection = con;
            dataAdapter.SelectCommand = cmd;
            dataAdapter.Fill(ds, "Login");
            if (ds.Tables[0].Rows.Count > 0)
            {
                var userId = (ds.Tables[0].Rows[0]).ItemArray[0].ToString();
                Response.Redirect("CreatePage.aspx?UserId=" + userId);
            }
            else
            {
                lblMsg.Text = "InValid User";
            }
        }
    }
}