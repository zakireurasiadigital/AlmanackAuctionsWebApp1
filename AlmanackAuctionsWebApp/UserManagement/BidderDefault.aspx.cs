using AlmanackAuctionsWebApp.App_Start.Clasess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmanackAuctionsWebApp.UserManagement
{
    public partial class BidderDefault : System.Web.UI.Page
    {
        tblusers objUser = new tblusers();
        int UserID, RoleID;
        protected void Page_Load(object sender, EventArgs e)
        {
            UserID = Convert.ToInt32(Session["UserId"]);
            RoleID = Convert.ToInt32(Session["RoleID"]);
            if (!IsPostBack)
            {
                gvMain.PageSize = 20;
                BindGridView();
            }
        }

        private void BindGridView()
        {
            DataTable dt = objUser.GetUserDetailsForView(RoleID, UserID, "2");
            if (dt != null && dt.Rows.Count > 0)
            {
                gvMain.DataSource = dt;
                gvMain.DataBind();
            }
        }
        protected void gvMain_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dt = objUser.GetUserDetailsForView(RoleID, UserID, "2");
            if (dt != null)
            {
                dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
                gvMain.DataSource = dt;
                gvMain.DataBind();
            }
        }
        private void BindGridViewForSearch()
        {
            DataTable dt = objUser.GetUserDetailsForView(RoleID, UserID, "2");
            if (dt != null)
            {
                string searchValue = txtSearch.Text.Trim();

                DataTable filteredData = dt.Clone();
                foreach (DataRow row in dt.Rows)
                {
                    bool found = false;
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (row[col.ColumnName].ToString().ToLower().Contains(searchValue.ToLower()))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        filteredData.ImportRow(row);
                    }
                }

                gvMain.DataSource = filteredData;
                gvMain.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGridViewForSearch();
        }

        protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMain.PageIndex = e.NewPageIndex;
            BindGridView();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            gvMain.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            BindGridView();
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";

            string previousSortExpression = ViewState["SortExpression"] as string;
            if (previousSortExpression != null && previousSortExpression == column && ViewState["SortDirection"] as string == "ASC")
            {
                sortDirection = "DESC";
            }

            ViewState["SortExpression"] = column;
            ViewState["SortDirection"] = sortDirection;

            return sortDirection;
        }

    }
}