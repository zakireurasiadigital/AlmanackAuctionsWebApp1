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
    public partial class UsersForm : System.Web.UI.Page
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
                    DivPassWord.Visible = false;
                    Edit();
                    btnSave.Text = "Update";
                }
            }

        }
        void Edit()
        {
            DataTable dt = objUser.GetUserDetailsForEdit(UrlUserID);
            txtUserName.Text = dt.Rows[0]["UserName"].ToString();
            txtPassword.Text = dt.Rows[0]["Password"].ToString();
            txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            txtLastName.Text = dt.Rows[0]["LastName"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtPostCode.Text = dt.Rows[0]["PostCode"].ToString();
            chkallowaddingUsers.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
            chkallowingBidders.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
            chkallowlisting.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);

        }
        void SaveUser(int AgentID)
        {
            objUser.UserID = UrlUserID;
            objUser.UserName = txtUserName.Text;
            objUser.Password = txtPassword.Text;
            objUser.FirstName = txtFirstName.Text;
            objUser.LastName = txtLastName.Text;
            objUser.CompanyName = Convert.ToString(Session["CompanyName"]);
            objUser.Address = txtAddress.Text;
            objUser.Postcode = txtPostCode.Text;
            objUser.Email = "";
            objUser.DateAdded = UrlUserID > 0 ? Convert.ToDateTime(objUser.GetDateAdded(UrlUserID)) : DateTime.Now;
            objUser.IsActive = true;
            objUser.AgentUserID = RoleID != 1 ? UserID : 0;
            objUser.AgentID = AgentID;
            objUser.UpdateByUserID = UrlUserID > 0 ? UserID : 0;
            objUser.AgentUserType = 1;
            objUser.DateUpdated = UrlUserID > 0 ? DateTime.Now : default(DateTime?);
            objUser.isAgnetUser_Listing_Allowed = chkallowaddingUsers.Checked;
            objUser.isAgnetUser_Bidder_Allowed = chkallowingBidders.Checked;
            objUser.is_Listing_Allowed = chkallowlisting.Checked;


            try
            {
                //aa=aa
                objUser.SaveUser();
            }
            catch (Exception ex)
            {

            }
        }
        void SaveRole()
        {
            objUserRole.UserRoleID = 0;
            objUserRole.UserID = (int)objUser.GetID();
            objUserRole.RoleID = 3;
            objUserRole.isActive = true;
            objUserRole.SaveData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsersDefault.aspx#add-region-tab");
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
                if (txtUserName.Text == "" || txtPassword.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtAddress.Text == "" || txtPostCode.Text == "")
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
                if (UrlUserID == 0)
                {
                    SaveRole();
                }

                Response.Redirect("UsersDefault.aspx#add-region-tab");
            }
            else
            {
                lblErrorMessage.Text = "Please fill in all required fields.";
            }
        }
    }
}