using AlmanackAuctionsWebApp.App_Start.Clasess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AlmanackAuctionsWebApp.UserManagement
{
    public partial class FormUsersEdit : System.Web.UI.Page
    {
        int UserID;
        tblusers objUser = new tblusers();
        tblUsersRole objUserRole = new tblUsersRole();
        int UrlUserID, RoleID;
        protected void Page_Load(object sender, EventArgs e)
        {
            // this is new changes for tesing github
            UrlUserID = Convert.ToInt32(Request.QueryString["i"]);
            UserID = Convert.ToInt32(Session["UserId"]);
            RoleID = Convert.ToInt32(Session["RoleID"]);
            if (!Page.IsPostBack)
            {
                if (UrlUserID > 0)
                {
                    Edit();
                    btnSave.Text = "Update";
                }
            }

        }
        void Edit()
        {
            DataTable dt = objUser.GetUserDetailsForEdit(UrlUserID);
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtPostCode.Text = dt.Rows[0]["PostCode"].ToString();
            chksActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
            chkallowaddingUsers.Checked = Convert.ToBoolean(dt.Rows[0]["isAgnetUser_Listing_Allowed"]);
            chkallowingBidders.Checked = Convert.ToBoolean(dt.Rows[0]["isAgnetUser_Bidder_Allowed"]);
            chkallowlisting.Checked = Convert.ToBoolean(dt.Rows[0]["is_Listing_Allowed"]);

        }
        void SaveUser(int AgentID)
        {
            objUser.UpdateUserAdminUser(txtUserName.Text, Convert.ToString(Session["CompanyName"]), txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtPostCode.Text, chksActive.Checked, AgentID, UrlUserID, UrlUserID,chkallowaddingUsers.Checked,chkallowingBidders.Checked,chkallowlisting.Checked);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DefaultUsers.aspx#add-region-tab");
        }
        private bool IsUserExists(string username)
        {
            DataTable dtUser = objUser.CheckUserNameExist(username, UrlUserID);
            if (dtUser != null && dtUser.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (txtUserName.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtAddress.Text == "" || txtPostCode.Text == "")
                {
                    lblErrorMessage.Text = "Please fill in all required fields.";
                    return;
                }

                if (IsUserExists(txtUserName.Text))
                {
                    lblErrorMessage.Text = "Username already exists.";
                    return;
                }

                DataTable dt = objUser.GetAgentID(Convert.ToString(Session["CompanyName"]));
                int agentID = 0;
                if (dt == null)
                {
                    agentID = Convert.ToInt32(dt.Rows[0]["AgentID"]);
                }
                if (agentID == 0)
                {
                    objUser.InsertAgent(Convert.ToString(Session["CompanyName"]));
                    DataTable dtt = objUser.GetAgentID(Convert.ToString(Session["CompanyName"]));
                    agentID = Convert.ToInt32(dtt.Rows[0]["AgentID"]);
                }

                SaveUser(agentID);
                Response.Redirect("DefaultUsers.aspx#add-region-tab");
            }
            else
            {
                lblErrorMessage.Text = "Please fill in all required fields.";
            }
        }
    }
}