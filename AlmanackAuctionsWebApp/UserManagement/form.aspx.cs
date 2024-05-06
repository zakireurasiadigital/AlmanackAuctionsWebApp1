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
    public partial class form : System.Web.UI.Page
    {
        int UserID;
        tblusers objUser = new tblusers();
        tblUsersRole objUserRole = new tblUsersRole();
        int UrlUserID, RoleID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UrlUserID = Convert.ToInt32(Request.QueryString["i"]);
            UserID = Convert.ToInt32(Session["UserId"]);
            RoleID = Convert.ToInt32(Session["RoleID"]);
            if (!Page.IsPostBack)
            {
               
                if (RoleID != 1)
                {
                    txtCompanyName.Text = Convert.ToString(Session["CompanyName"]);
                    DivCompnayName.Visible = false;
                    DivEmail.Visible = false;
                }
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
            txtCompanyName.Text = dt.Rows[0]["CompanyName"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtPostCode.Text = dt.Rows[0]["PostCode"].ToString();
            txtEmail.Text = dt.Rows[0]["Email"].ToString();
            chkIsActive.Checked = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
            DivIsActive.Visible = true;

        }
        void SaveUser(int AgentID)
        {
            objUser.UserID = UrlUserID;
            objUser.UserName = txtUserName.Text;
            objUser.Password = txtPassword.Text;
            objUser.FirstName = txtFirstName.Text;
            objUser.LastName = txtLastName.Text;
            objUser.CompanyName = RoleID != 1 ? Convert.ToString(Session["CompanyName"]) : txtCompanyName.Text;
            objUser.Address = txtAddress.Text;
            objUser.Postcode = txtPostCode.Text;
            objUser.Email = txtEmail.Text;
            objUser.DateAdded = UrlUserID > 0 ? Convert.ToDateTime(objUser.GetDateAdded(UrlUserID)) : DateTime.Now;
            objUser.IsActive = UrlUserID > 0 ? chkIsActive.Checked : true;
            objUser.AgentUserID = RoleID != 1 ? UserID : 0;
            objUser.AgentID = AgentID;
            objUser.UpdateByUserID = UrlUserID > 0 ? UserID : 0;
            objUser.DateUpdated = UrlUserID > 0 ? DateTime.Now : default(DateTime?);
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
            objUserRole.RoleID = RoleID == 1 ? 2 : RoleID == 2 ? 3 : 0;
            objUserRole.isActive = true;
            objUserRole.SaveData();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx#add-region-tab");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (txtUserName.Text == "" || txtPassword.Text == "" || txtCompanyName.Text == "" || txtFirstName.Text == "" || txtLastName.Text == "" || txtAddress.Text == "" || txtPostCode.Text == "" || (txtEmail.Text == "" && RoleID ==1))
                {
                    lblErrorMessage.Text = "Please fill in all required fields.";
                    return; 
                }
                DataTable dt = objUser.GetAgentID(txtCompanyName.Text);
                int agentID = 0;
                if (dt == null)
                {
                    agentID = Convert.ToInt32(dt.Rows[0]["AgentID"]);
                }
                if (agentID == 0)
                {
                    objUser.InsertAgent(txtCompanyName.Text);
                    DataTable dtt = objUser.GetAgentID(txtCompanyName.Text);
                    agentID = Convert.ToInt32(dtt.Rows[0]["AgentID"]);
                }

                SaveUser(agentID);
                if (UrlUserID == 0)
                {
                    SaveRole();
                }

                Response.Redirect("Default.aspx#add-region-tab");
            }
            else
            {
                lblErrorMessage.Text = "Please fill in all required fields.";
            }
        }
    }
}