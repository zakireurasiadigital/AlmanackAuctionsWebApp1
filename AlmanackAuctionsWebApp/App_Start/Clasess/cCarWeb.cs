using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;

namespace AlmanackAuctionsWebApp.App_Start.Clasess
{
    public class cCarWeb
    {
        public static string ApiUsername = "CompleteSalvage";
        public static string ApiPassword = "77773334";
        public static string ApiKey1 = "cs34fg76";
        public static string ApiVersion = "0.31.1";
        
        public static DataSet GetVRM(string strVRM)
        {
            CarWebWs.CarweBVRRWebService oCarWebService = new CarWebWs.CarweBVRRWebService();
            DataSet ds = new DataSet();
            try
            {
                ds = null;
                XmlNode xn;
                xn = oCarWebService.strB2BGetVehicleByVRM(ApiUsername, ApiPassword, "test", "test", ApiKey1, strVRM, ApiVersion);
                ds = ConvertXmlToDataset(xn);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            return ds;
        }
        public static DataSet ConvertXmlToDataset(XmlNode node)
        {
            // declaring data set object
            DataSet ds = new DataSet();
            ds = null;
            if (node != null)
            {
                XmlTextReader xtr = new XmlTextReader(node.OuterXml, XmlNodeType.Element, null/* TODO Change to default(_) if this is not a reference type */);
                ds = new DataSet();
                ds.ReadXml(xtr);
            }
            return ds;
        }

        //public static bool IsVehicleAllowed(string Category)
        //{
        //    if (IsManualQuote())
        //        return true;
        //    else if (Category.Contains("HCVs") | Category.Contains("SPVs") | Category.Contains("PSVs") | Category.Contains("2/3"))
        //        return false;
        //    else
        //        return true;
        //}


        //public static cCarDetails AddCar(string strVRM)
        //{
        //    cCarWeb lCarWeb = new cCarWeb();

        //    DataSet dsCarDetail = GetVRM(strVRM);
        //    DataTable dtCarDetail;

        //    cCarDetails oCarDetails = new cCarDetails();


        //    // Fail Over thing for CarWeb ''''
        //    try
        //    {
        //        if (dsCarDetail.Tables.Contains("Vehicle") == true)
        //        {
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        dsCarDetail = cCarWeb2.GetVRM(strVRM);
        //        try
        //        {
        //            if (dsCarDetail.Tables.Contains("Vehicle") == true)
        //            {
        //            }
        //        }
        //        catch (Exception ex2)
        //        {
        //            dsCarDetail = cCarWeb3.GetVRM(strVRM);
        //            try
        //            {
        //                if (dsCarDetail.Tables.Contains("Vehicle") == true)
        //                {
        //                }
        //            }
        //            catch (Exception ex3)
        //            {
        //                dsCarDetail = cCarWebMain.GetVRM(strVRM);
        //                try
        //                {
        //                    if (dsCarDetail.Tables.Contains("Vehicle") == true)
        //                    {
        //                    }
        //                }
        //                catch (Exception ex4)
        //                {
        //                }
        //            }
        //        }
        //    }

        //    // Fail Over thing for CarWeb ''''


        //    if (dsCarDetail.Tables.Contains("Vehicle") == true)
        //    {
        //        dtCarDetail = dsCarDetail.Tables["Vehicle"].Copy();

        //        if (dtCarDetail.Rows[0].Item["DVLAYearOfManufacture"] == "")
        //        {
        //            if (dtCarDetail.Rows[0].Item["DateFirstRegistered"] != "")
        //            {
        //                dtCarDetail.Rows[0].Item["DVLAYearOfManufacture"] = Conversion.Val((DateTime)dtCarDetail.Rows[0].Item["DateFirstRegistered"].Year);
        //                dtCarDetail.AcceptChanges();
        //            }
        //        }

        //        if (dtCarDetail.Rows[0].Item["DVLAYearOfManufacture"] != "")
        //        {
        //            oCarDetails = lCarWeb.InsertCarDetails(dtCarDetail);
        //            if (!cCarWeb.IsVehicleAllowed(dtCarDetail.Rows[0]["VehicleCategoryDescription"]))
        //                oCarDetails.ModelYear = 123;
        //        }
        //    }

        //    return oCarDetails;
        //}

        //public cCarDetails InsertCarDetails(DataTable dt)
        //{
        //    cCarDetails oCarDetails = new cCarDetails();
        //    if (dt.Rows.Count > 0)
        //    {
        //        DataRow rs = dt.Rows[0];

        //        string oCarExistCheck = "SELECT * FROM tblCardetails WHERE VRM_Curr='" + rs["VRM_Curr"] + "'";
        //        DataTable dtCarCheck = cFunctions.RunQuery(oCarExistCheck);

        //        oCarDetails.VRM_Curr = rs["VRM_Curr"];
        //        oCarDetails.Combined_EngineCapacity = TrySet(rs["Combined_EngineCapacity"], 0);
        //        oCarDetails.Combined_ForwardGears = TrySet(rs["Combined_ForwardGears"], 0);
        //        oCarDetails.Combined_FuelType = TrySet(rs["Combined_FuelType"], "");
        //        oCarDetails.Combined_Make = TrySet(rs["Combined_Make"], "");
        //        oCarDetails.Combined_Model = TrySet(rs["Combined_Model"], "");
        //        oCarDetails.Combined_Transmission = TrySet(rs["Combined_Transmission"], "");
        //        if (Information.IsNumeric(rs["ModelYear"]))
        //            oCarDetails.ModelYear = TrySet(rs["ModelYear"], 0);
        //        else
        //            oCarDetails.ModelYear = 0;
        //        oCarDetails.DVLAYearOfManufacture = TrySet(rs["DVLAYearOfManufacture"], 0);
        //        oCarDetails.ColourCurrent = TrySet(rs["ColourCurrent"], "");
        //        oCarDetails.BodyStyleDescription = TrySet(rs["BodyStyleDescription"], "");
        //        oCarDetails.NumberOfDoors = TrySet(rs["NumberOfDoors"], 0);
        //        oCarDetails.GrossWeightKG = TrySet(rs["GrossWeightKG"], 0);
        //        oCarDetails.KerbWeightMin = TrySet(rs["KerbWeightMin"], 0);
        //        oCarDetails.KerbWeightMax = TrySet(rs["KerbWeightMax"], 0);
        //        oCarDetails.VehicleImageUrl = TrySet(rs["VehicleImageUrl"], "");
        //        oCarDetails.EstPrivateSale = 0.0;
        //        oCarDetails.EstTrandIn = 0.0;
        //        oCarDetails.EstAuction = 0.0;
        //        oCarDetails.DateFirstRegistered = TrySet(rs["DateFirstRegistered"], (DateTime)"01-01-1900");
        //        oCarDetails.StartDateOfCurrentKeeper = TrySet(rs["StartDateOfCurrentKeeper"], (DateTime)"01-01-1900");
        //        if (Information.IsDate(rs["DateFirstRegistered"]) == false | rs["DateFirstRegistered"] == "")
        //            oCarDetails.DateFirstRegistered = (DateTime)"01-01-1900";
        //        if (Information.IsDate(rs["StartDateOfCurrentKeeper"]) == false | rs["StartDateOfCurrentKeeper"] == "")
        //            oCarDetails.StartDateOfCurrentKeeper = (DateTime)"01-01-1900";

        //        oCarDetails.NumberOfPreviousKeepers = TrySet(rs["NumberOfPreviousKeepers"], 0);
        //        oCarDetails.EngineNumber = TrySet(rs["EngineNumber"], "");
        //        oCarDetails.EngineModelCode = TrySet(rs["EngineModelCode"], "");
        //        oCarDetails.VIN_Original_DVLA = TrySet(rs["VIN_Original_DVLA"], "");

        //        if (dtCarCheck.Rows.Count == 0)
        //            oCarDetails.Insert();

        //        oCarDetails.Exists = true;
        //    }

        //    return oCarDetails;
        //}

        //public cCarDetails UpdateCarDetails(DataTable dtCarDetail)
        //{
        //    cCarDetails oCarDetails = new cCarDetails();
        //    oCarDetails.VRM_Curr = dtCarDetail.Rows[0].Item["VRM_Curr"];
        //    DataTable dt = oCarDetails.GetData("*", "VRM_Curr", "");
        //    if (dt.Rows.Count > 0)
        //    {
        //        oCarDetails.CarDetailId = dt.Rows[0].Item["CarDetailId"];

        //        oCarDetails.EngineNumber = lGeneral.TrySet(dtCarDetail.Rows[0].Item["EngineNumber"], "-1");
        //        oCarDetails.EngineModelCode = lGeneral.TrySet(dtCarDetail.Rows[0].Item["EngineModelCode"], "-1");
        //        oCarDetails.VIN_Original_DVLA = lGeneral.TrySet(dtCarDetail.Rows[0].Item["VIN_Original_DVLA"], "-");

        //        oCarDetails.NumberOfPreviousKeepers = lGeneral.TrySet(dtCarDetail.Rows[0].Item["NumberOfPreviousKeepers"], 0);
        //        oCarDetails.VehicleImageUrl = lGeneral.TrySet(dtCarDetail.Rows[0].Item["VehicleImageUrl"], "");
        //        oCarDetails.DateUpdated = DateTime.Now.Date;

        //        oCarDetails.GrossWeightKG = TrySet(dtCarDetail.Rows[0].Item["GrossWeightKG"], 0);
        //        oCarDetails.KerbWeightMin = TrySet(dtCarDetail.Rows[0].Item["KerbWeightMin"], 0);
        //        oCarDetails.KerbWeightMax = TrySet(dtCarDetail.Rows[0].Item["KerbWeightMax"], 0);

        //        oCarDetails.Update("GrossWeightKG,KerbWeightMin,KerbWeightMax,EngineNumber,NumberOfPreviousKeepers,EngineModelCode,VIN_Original_DVLA,VehicleImageUrl,DateUpdated", "CarDetailId");
        //        oCarDetails.Reset();
        //        oCarDetails.VRM_Curr = dtCarDetail.Rows[0].Item["VRM_Curr"];
        //        oCarDetails.LoadByRS(oCarDetails.GetData("*", "VRM_Curr", ""));
        //        oCarDetails.Exists = true;
        //    }
        //    return oCarDetails;
        //}
         
    }
}