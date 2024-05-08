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
    public partial class Default : System.Web.UI.Page
    {
        public int UserID, RoleID;
        tblusers objUser = new tblusers();
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
                    btnAddBidders.Visible = false;
                }
                else if (RoleID == 2)
                {
                    btnUsers.Visible = true;
                    btnListings.Visible = true;
                    btnAddBidders.Visible = true;
                    btnAdminUsers.Visible = false;
                }
                else if (RoleID == 3)
                {
                    DataTable userData = objUser.RetrieveUserData(UserID);
                    if (userData != null && userData.Rows.Count > 0)
                    {
                        bool isListingAllowed = Convert.ToBoolean(userData.Rows[0]["is_Listing_Allowed"]);
                        btnListings.Visible = isListingAllowed;

                        bool isUserListingAllowed = Convert.ToBoolean(userData.Rows[0]["isAgnetUser_Listing_Allowed"]);
                        btnUsers.Visible = isUserListingAllowed;

                        bool isBidderAllowed = Convert.ToBoolean(userData.Rows[0]["isAgnetUser_Bidder_Allowed"]);
                        btnAddBidders.Visible = isBidderAllowed;

                        btnAdminUsers.Visible = false;
                    }
                }
                else if (RoleID == 4)
                {
                    btnUsers.Visible = false;
                    btnListings.Visible = true;
                    btnAdminUsers.Visible = false;
                    btnAddBidders.Visible = false;
                }
            }
        }

        protected void btnListings_Click(object sender, EventArgs e)
        {

        }

        protected void btnUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManagement/UsersDefault.aspx");
        }

        protected void btnAddBidders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManagement/BidderDefault.aspx");
        }

        protected void btnAdminUsers_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserManagement/Default.aspx");
        }
    }
}