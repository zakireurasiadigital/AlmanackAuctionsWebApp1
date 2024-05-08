using AlmanackAuctionsWebApp.App_Start.Clasess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmanackAuctionsWebApp.UserManagement
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        int UserID;
        tblusers objUser = new tblusers();
        int UrlUserID, RoleID;
        string UserType;
        protected void Page_Load(object sender, EventArgs e)
        {
            UrlUserID = Convert.ToInt32(Request.QueryString["i"]);
            UserID = Convert.ToInt32(Session["UserId"]);
            RoleID = Convert.ToInt32(Session["RoleID"]);
            UserType = Convert.ToString(Request.QueryString["UserType"]);


        }
        protected void btnCloseModal_Click(object sender, EventArgs e)
        {
            if (UserType == "AdminUser")
            {
                Response.Redirect("UsersDefault.aspx#add-region-tab");
            }
            else if (UserType == "Bidder")
            {
                Response.Redirect("BidderDefault.aspx#add-region-tab");
            }
            else if (UserType == "Superadmin")
            {
                Response.Redirect("Default.aspx#add-region-tab");
            }
        }

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (newPassword == confirmPassword)
            {
                objUser.UpdatePasswrod(confirmPassword, UrlUserID);

                if (UserType == "AdminUser")
                {
                    Response.Redirect("UsersDefault.aspx#add-region-tab");
                }
                else if (UserType == "Bidder")
                {
                    Response.Redirect("BidderDefault.aspx#add-region-tab");
                }
                else if (UserType == "Superadmin")
                {
                    Response.Redirect("Default.aspx#add-region-tab");
                }


            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Passwords do not match.');", true);
            }
        }
    }
}