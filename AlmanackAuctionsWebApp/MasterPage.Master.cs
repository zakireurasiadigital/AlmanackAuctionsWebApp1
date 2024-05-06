using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmanackAuctionsWebApp
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        int UserId, VenderLibraryID, RoleId;
        string CompanyName;
        protected int mintTimeout;
        protected void Page_Init(object sender, System.EventArgs e)
        {
            if (Session["UserID"] == null)
                Response.Redirect("~/Login.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = Convert.ToInt32(Session["UserID"]);
            RoleId = Convert.ToInt32(Session["RoleID"]);
            CompanyName = Convert.ToString(Session["CompanyName"]);

        }
    }
}