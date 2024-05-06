using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmanackAuctionsWebApp
{
    public partial class Default : System.Web.UI.Page
    {
        int UserID, RoleID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt32(Session["UserId"]);
            RoleID = Convert.ToInt32(Session["RoleID"]);
            if (!Page.IsPostBack)
            {
                if (RoleID == 1)
                {
                    btnUsers.Visible = false;
                    btnListings.Visible = false;
                    btnAdminUsers.Visible = true;
                }
                else if (RoleID == 2)
                {
                    btnUsers.Visible = true;
                    btnListings.Visible = true;
                    btnAdminUsers.Visible = false;
                }
                else if (RoleID == 3)
                {
                    btnUsers.Visible = false;
                    btnListings.Visible = true;
                    btnAdminUsers.Visible = false;
                }
            }
        }

        protected void btnListings_Click(object sender, EventArgs e)
        {

        }

        protected void btnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManagement/Default.aspx");
        }

        protected void btnAdminUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManagement/Default.aspx");
        }
    }
}