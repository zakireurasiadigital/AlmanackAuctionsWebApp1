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
        int UserId, RoleId;
        string CompanyName;
        protected int mintTimeout;
        protected void Page_Init(object sender, System.EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                UserId = Convert.ToInt32(Session["UserId"]);
                DataTable dt = cFunction.GetDataTable("Select * from tblSiteConfiguration where AgentUserID=" + UserId.ToString());
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

        }
    }
}