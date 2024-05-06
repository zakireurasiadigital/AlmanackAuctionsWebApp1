using AlmanackAuctionsWebApp.DBLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmanackAuctionsWebApp.BusinessLayer.Region
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        DataTable dtData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        public void FillGrid()
        {
            dtData = sFunctions.RunQuery("select 11 as RegionId, 22 as A ,33 as B,33 as C  UNION ALL    select 11 as RegionId, 22 as A ,33 as B,33 as C   UNION ALL    select 11 as RegionId, 22 as A ,33 as B,33 as C   UNION ALL    select 11 as RegionId, 22 as A ,33 as B,33 as C   UNION ALL    select 11 as RegionId, 22 as A ,33 as B,33 as C");
            System.Data.DataView dvData = new System.Data.DataView(dtData);

            gvMain.DataSource = dtData;
            gvMain.DataBind();
           
        }

    }




}