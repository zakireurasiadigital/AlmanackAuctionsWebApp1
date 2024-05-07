using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AlmanackAuctionsWebApp.App_Start.Clasess
{
    public class tblusers : SQLManager
    {
        public tblusers()
        {
            m_strTableName = "tblUsers";
            m_strPrimaryFieldName = "UserID";
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType;
        }

        public long UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public DateTime? DateAdded { get; set; }
        public bool? IsActive { get; set; }
        public long? AgentUserID { get; set; }
        public long? AgentID { get; set; }
        public DateTime? DateUpdated { get; set; }
        public long? UpdateByUserID { get; set; }
        public long? AgentUserType { get; set; }
        public bool? isAgnetUser_Listing_Allowed { get; set; }
        public bool? isAgnetUser_Bidder_Allowed { get; set; }
        public bool? is_Listing_Allowed { get; set; }

        public void SaveUser()
        {
            try
            {
                this.Save();
            }
            catch (Exception)
            {
            }
        }
        public long GetID()
        {
            return this.GetCurrentId();
        }
        public DataTable GetUserDetails(string UserName, string password)
        {
            string str = "Select top 1 * from tblUsers Users Inner join tblUsersRole UserRole on Users.UserId=UserRole.UserId Where UserName='" + UserName + "' and Password='" + password + "'";
            try
            {
                return this.GetDataTable(str);
            }
            catch (Exception) { }
            return null;
        }
        public DataTable GetUserDetailsForView(int RoleID, int UserID,string AgentUserType)
        {
            string str = "";
            if (RoleID == 1)
            {
                str += "Select *,CASE WHEN IsActive = 0 THEN 'No' ELSE 'Yes' End as Status from tblUsers where AgentUserID = 0 AND userid <>1 ";
            }
            else if (RoleID != 1)
            {
                str += "Select *,CASE WHEN IsActive = 0 THEN 'No' ELSE 'Yes' End as Status from tblUsers where AgentUserID = " + UserID + " and AgentUserType = '"+ AgentUserType + "' ";
            }
            try
            {
                return this.GetDataTable(str);
            }
            catch (Exception) { }
            return null;
        }
        public DataTable GetUserDetailsForEdit(int UserID)
        {
            string str = "Select * from tblUsers where UserID = " + UserID + " ";
            try
            {
                return this.GetDataTable(str);
            }
            catch (Exception) { }
            return null;
        }
        public DataTable GetAgentID(string CompanyName)
        {
            string str = "Select AgentID from tblAgents where AgentName = '" + CompanyName + "' ";
            try
            {
                return this.GetDataTable(str);
            }
            catch (Exception) { }
            return null;
        }
        public void InsertAgent(string AgentName)
        {
            string str = "INSERT INTO tblAgents VALUES ('" + AgentName + "',GETDATE())";
            try
            {
                this.ExecuteNonQuery(str);
            }
            catch (Exception) { }
        }
        public string GetDateAdded(int userID)
        {
            string str = "SELECT DateAdded FROM tblUsers WHERE UserID = '" + userID + "' ";
            try
            {
                return this.GetScaler(str);
            }
            catch (Exception) { }
            return null;
        }
        public void InsertLoginUser(int UserID)
        {
            string str = "INSERT INTO tblLoginLog VALUES (" + UserID + ",'','','',GETDATE())";
            try
            {
                this.ExecuteNonQuery(str);
            }
            catch (Exception) { }
        }
        public DataTable CheckUserNameExist(string UserName,int UserID)
        {
            string str = "Select * from tblUsers where UserName = '" + UserName + "' and UserID <> "+ UserID + " ";
            try
            {
                return this.GetDataTable(str);
            }
            catch (Exception) { }
            return null;
        }
        public DataTable CheckEmailExist(string Email, int UserID)
        {
            string str = "Select * from tblUsers where Email = '" + Email + "' and UserID <> "+ UserID + " ";
            try
            {
                return this.GetDataTable(str);
            }
            catch (Exception) { }
            return null;
        }
        public void UpdateUserSuperAdmin(string UserName,string CompanyName,string FirstName,string LastName,string Address,string Postcode,string Email,bool IsActive,int AgentID, int UpdateByUserID,int UserID)
        {
            string str = "UPDATE tblUsers SET UserName='"+ UserName + "',CompanyName='"+ CompanyName + "',FirstName='"+ FirstName + "',LastName='"+ LastName + "',Address='"+ Address + "',Postcode='"+ Postcode + "',Email='"+ Email + "',isActive='"+ IsActive + "',AgentID="+ AgentID + ",DateUpdated=GETDATE(),UpdateByUserID="+ UpdateByUserID + " WHERE UserID="+ UserID + "";
            try
            {
                this.ExecuteNonQuery(str);
            }
            catch (Exception) { }
        }
        public void UpdateUserAdminUser(string UserName, string CompanyName, string FirstName, string LastName, string Address, string Postcode, bool IsActive, int AgentID, int UpdateByUserID, int UserID,bool isAgnetUser_Listing_Allowed,bool isAgnetUser_Bidder_Allowed,bool is_Listing_Allowed)
        {
            string str = "UPDATE tblUsers SET UserName='" + UserName + "',CompanyName='" + CompanyName + "',FirstName='" + FirstName + "',LastName='" + LastName + "',Address='" + Address + "',Postcode='" + Postcode + "',isActive='" + IsActive + "',AgentID=" + AgentID + ",DateUpdated=GETDATE(),UpdateByUserID=" + UpdateByUserID + ",isAgnetUser_Listing_Allowed='"+ isAgnetUser_Listing_Allowed + "',isAgnetUser_Bidder_Allowed = '"+ isAgnetUser_Bidder_Allowed + "',is_Listing_Allowed = '"+ is_Listing_Allowed + "' WHERE UserID=" + UserID + "";
            try
            {
                this.ExecuteNonQuery(str);
            }
            catch (Exception) { }
        }
        public void UpdateUserBidder(string UserName, string CompanyName, string FirstName, string LastName, string Address, string Postcode, string Email, bool IsActive, int AgentID, int UpdateByUserID, int UserID)
        {
            string str = "UPDATE tblUsers SET UserName='" + UserName + "',CompanyName='" + CompanyName + "',FirstName='" + FirstName + "',LastName='" + LastName + "',Address='" + Address + "',Postcode='" + Postcode + "',Email='" + Email + "',isActive='" + IsActive + "',AgentID=" + AgentID + ",DateUpdated=GETDATE(),UpdateByUserID=" + UpdateByUserID + " WHERE UserID=" + UserID + "";
            try
            {
                this.ExecuteNonQuery(str);
            }
            catch (Exception) { }
        }
        public DataTable RetrieveUserData(int userID)
        {
            string str = "Select is_Listing_Allowed,isAgnetUser_Listing_Allowed,isAgnetUser_Bidder_Allowed from tblUsers where UserID = "+userID+" ";
            try
            {
                return this.GetDataTable(str);
            }
            catch (Exception) { }
            return null;
        }
    }
}