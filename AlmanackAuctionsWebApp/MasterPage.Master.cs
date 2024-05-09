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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public int UserId, RoleId, AgentID;
        string CompanyName;
        protected int mintTimeout;
        public string DisplayName = "";
        protected void Page_Init(object sender, System.EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                AgentID = Convert.ToInt32(Session["AgentID"]);
                DataTable dt = cFunction.GetDataTable("Select * from tblSiteConfiguration where AgentID=" + AgentID.ToString());
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SiteHeaderLogoURL"] != null)
                    {
                        imgLogo.Src = dt.Rows[0]["SiteHeaderLogoURL"].ToString();
                    }

                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            UserId = Convert.ToInt32(Session["UserID"]);
            RoleId = Convert.ToInt32(Session["RoleID"]);
            CompanyName = Convert.ToString(Session["CompanyName"]);

            if ( RoleId==1)
            {
                DisplayName = Convert.ToString(Session["CompanyName"]);
            }
            else if (RoleId == 2)
            {
                DisplayName = Convert.ToString(Session["CompanyName"]);
            }
            else if (RoleId == 3)
            {
                DisplayName = Convert.ToString(Session["FirstName"]);
            }
            else if (RoleId == 4)
            {
                DisplayName = Convert.ToString(Session["CompanyName"]);
            }
        }

    }
}