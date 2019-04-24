using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Class
/// </summary>
namespace TestApplication
{
    public partial class CreatePage : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sagar\OneDrive\Desktop\.net material\TestApplication\Database\TestDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        /// <summary>
        /// PageLoad method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnDelete.Enabled = false;
                ShowGridView();
            }
        }

        /// <summary>
        /// Clear button method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();
        }

        /// <summary>
        /// Clearing the all fields
        /// </summary>
        public void ClearAllFields()
        {
            hfStackId.Value = "";
            txtfruit.Text = txtquantity.Text = txtvariety.Text = "";
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            lblMsg.Text = lbError.Text = "";
        }

        /// <summary>
        /// Save button method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
                SqlCommand cmd = new SqlCommand("StackCreateOrUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Fruit", txtfruit.Text.Trim());
                cmd.Parameters.AddWithValue("@Variety", txtvariety.Text.Trim());
                cmd.Parameters.AddWithValue("@Quantity", txtquantity.Text.Trim());
            cmd.Parameters.AddWithValue("@UserId", Request.QueryString["UserId"] == "" ? 0 : Convert.ToInt32(Request.QueryString["UserId"]));
            cmd.Parameters.AddWithValue("@StackId", hfStackId.Value == "" ? 0 : Convert.ToInt32(hfStackId.Value));
                 cmd.ExecuteNonQuery();
                con.Close();
            string stackId = hfStackId.Value;
                ShowGridView();
                if (stackId == "")
                    lblMsg.Text = "Saved Successfully";
                else
                    lblMsg.Text = "Updated Successfully";

        }

        /// <summary>
        /// Show all the Grid fields
        /// </summary>
        public void ShowGridView()
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("StackViewAll", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            con.Close();
            gridData.DataSource = dt;
            gridData.DataBind();
        }

        /// <summary>
        /// To show the specific Stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gridView_OnClick(object sender, EventArgs e)
        {
            int stackId = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("StackViewByID", con);
            dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            dataAdapter.SelectCommand.Parameters.AddWithValue("@StackId", stackId);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            con.Close();
            hfStackId.Value = stackId.ToString();
            txtfruit.Text = dt.Rows[0]["Fruit"].ToString();
           //txtvariety.Text = dt.Rows[0]["Varierty"].ToString();
            txtquantity.Text = dt.Rows[0]["Quantity"].ToString();
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }

        /// <summary>
        /// Delete specific Stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand cmd = new SqlCommand("StackDeleteByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StackId", Convert.ToInt32(hfStackId.Value));
            cmd.ExecuteNonQuery();
            con.Close();
            ClearAllFields();
            ShowGridView();
            lblMsg.Text = "Deleted Successfully";
        }
    }
}