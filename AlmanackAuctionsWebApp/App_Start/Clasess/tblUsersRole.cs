using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace AlmanackAuctionsWebApp.App_Start.Clasess
{
    public class tblUsersRole : SQLManager
    {
        public tblUsersRole()
        {
            m_strTableName = "tblUsersRole";
            m_strPrimaryFieldName = "UserRoleID";
            m_enPrimaryFieldDataType = SQLManager.DataTypes.LongType;
        }
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public bool isActive { get; set; }

        public Boolean SaveData()
        {
            try
            {
                this.Save();
                return true;
            }
            catch (Exception) { }
            return false;
        }


        public void ExecuteQuery(string strQuery)
        {
            try
            {
                this.ExecuteNonQuery(strQuery);
            }
            catch (Exception) { }
        }

        public long GetID()
        {
            return this.GetCurrentId();
        }
    }
}