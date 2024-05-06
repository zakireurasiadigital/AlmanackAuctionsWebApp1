using AlmanackAuctionsWebApp.App_Start.Clasess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmanackAuctionsWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        tblusers objtblusers = new tblusers();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            DataTable dt = objtblusers.GetUserDetails(txtUsername.Text, txtPassword.Text);
            if (dt.Rows.Count > 0)
            {
                int UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                Session["RoleID"] = dt.Rows[0]["RoleID"].ToString();
                Session["FirstName"] = dt.Rows[0]["FirstName"].ToString();
                Session["LastName"] = dt.Rows[0]["LastName"].ToString();
                Session["CompanyName"] = dt.Rows[0]["CompanyName"].ToString();
                objtblusers.InsertLoginUser(UserID);
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid login credentials.";
                lblMessage.Visible = true;
            }
        }
    }
}