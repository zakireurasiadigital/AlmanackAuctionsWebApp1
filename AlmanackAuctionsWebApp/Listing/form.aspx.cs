using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlmanackAuctionsWebApp.Listing
{
    public partial class form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


    //    Sub ProcessVRM()
    //    'Check if VRM is in the Database

    //    Dim IsAdded As Boolean = False
    //    Dim dsCarDetail As New DataSet

    //    'IF NOT A CAR THEN REDIRECT TO FAIL.aspx?type=8
    //    '###############  WE CAN NOT FOLLOW THIS PROCESS AS WE NEED TO HAVE ENGINE CODE AND NUMBER OF PREVIOUS OWNERS FROM CARWEB #######################
    //    If 1 = 1 Then
    //        oCarDetails.VRM_Curr = oInitialQuote.RegNo
    //        oCarDetails.LoadByRS(oCarDetails.GetData("*", "VRM_Curr", ""))
    //        If Not oCarDetails.Exists Then  'Lets try to load it
    //            oCarDetails = cCarWeb.AddCar(oCarDetails.VRM_Curr)

    //            IsAdded = True
    //            If Not oCarDetails.Exists Then
    //                Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmNotFound & "&iqid=" & oInitialQuote.InitialQuoteId)  'Fail it as car does not exist
    //            ElseIf oCarDetails.ModelYear = 123 Then
    //                Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmInvalid & "&iqid=" & oInitialQuote.InitialQuoteId)  'Fail it as not allowed bikes ...etc
    //            End If
    //        Else
    //            If oCarDetails.EngineModelCode = "" Then ' Data exist in tblCarDetails but EngineCode is missing
    //                dsCarDetail = cCarWeb.GetVRM(oInitialQuote.RegNo)

    //                dsCarDetail = cCarWeb2.GetVRM(oInitialQuote.RegNo)
    //                'Fail Over
    //                Try
    //                    If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //                        'do nothing
    //                    End If
    //                Catch ex As Exception
    //                    dsCarDetail = cCarWeb3.GetVRM(oInitialQuote.RegNo)
    //                    Try
    //                        If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //                            'do nothing
    //                        End If
    //                    Catch ex2 As Exception
    //                        dsCarDetail = cCarWeb.GetVRM(oInitialQuote.RegNo)
    //                        Try
    //                            If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //                                'do nothing
    //                            End If
    //                        Catch ex3 As Exception
    //                            dsCarDetail = cCarWebMain.GetVRM(oInitialQuote.RegNo)
    //                            Try
    //                                If dsCarDetail.Tables.Contains("Vehicle") = True Then

    //                                End If
    //                            Catch ex4 As Exception
    //                                'All Failed
    //                            End Try
    //                        End Try
    //                    End Try
    //                End Try
    //                'Fail Over


    //                If dsCarDetail Is Nothing Then
    //                    Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.CarWebFail & "&iqid=" & oInitialQuote.InitialQuoteId)  'Fail it as car does not exist
    //                Else
    //                    If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //                        dtCarDetail = dsCarDetail.Tables("Vehicle").Copy()
    //                        If dtCarDetail.Rows.Count > 0 Then
    //                            If cCarWeb.IsVehicleAllowed(dtCarDetail.Rows(0)("VehicleCategoryDescription")) Then
    //                                'oCarDetails = lCarWeb.UpdateCarDetails(dtCarDetail)
    //                                'IsAdded = True
    //                                If Not oCarDetails.Exists Then
    //                                    Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmNotFound & "&iqid=" & oInitialQuote.InitialQuoteId)  'Fail it as car does not exist
    //                                End If
    //                            Else
    //                                Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmInvalid & "&iqid=" & oInitialQuote.InitialQuoteId)  'Fail it as car not allowed
    //                            End If
    //                        Else
    //                            Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmNotFound & "&iqid=" & oInitialQuote.InitialQuoteId)  'Fail it as car does not exist
    //                        End If

    //                    Else
    //                        Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmNotFound & "&iqid=" & oInitialQuote.InitialQuoteId)  'Fail it as car does not exist
    //                    End If
    //                End If
    //                'Else
    //                'oCarDetails = lCarWeb.UpdateCarDetails(dtCarDetail)
    //            End If
    //        End If
    //    End If
    //    '###############  WE CAN NOT FOLLOW THIS PROCESS AS WE NEED TO HAVE ENGINE CODE AND NUMBER OF PREVIOUS OWNERS FROM CARWEB #######################

    //    '### Add Car To Almanack #####
    //    If oCarDetails.Exists Then
    //        Dim oAlmanac As New lAlmanack
    //        oAlmanac.AddCars(oCarDetails)
    //    End If
    //    '### Add Car To Almanack #####

    //    '### Add Car To SCC #####
    //    If oCarDetails.Exists Then
    //        Dim oScrapCarCompare As New lScrapCarCompare
    //        oScrapCarCompare.AddCars(oCarDetails)
    //    End If
    //    '### Add Car To SCC #####

    //    '############### START CHECK CDLVIS #######################
    //    If oCarDetails.Exists And oCarDetails.EstAuction = 0 Then

    //        Dim dtmatch As New DataTable
    //        oCarDetails.CarDetailId = oCarDetails.CarDetailId
    //        Try
    //            Dim oCDLVIS As New cCDLVIS
    //            Dim dsCDLVIS As DataSet = cCDLVIS.GetCDLVIS(oCarDetails.VRM_Curr)
    //            If dsCDLVIS.Tables.Contains("match") = True Then
    //                dtmatch = dsCDLVIS.Tables("match").Copy()
    //                If dtmatch.Rows.Count > 0 Then
    //                    oCarDetails.EstAuction = dtmatch.Rows(0).Item("trade")
    //                    oCarDetails.EstPrivateSale = dtmatch.Rows(0).Item("retail") ' Retail
    //                    oCarDetails.EstTrandIn = dtmatch.Rows(0).Item("trade")
    //                End If
    //            Else
    //                oCarDetails.EstAuction = -1
    //                oCarDetails.EstPrivateSale = -1
    //                oCarDetails.EstTrandIn = -1
    //            End If
    //            oCarDetails.Update("EstAuction,EstPrivateSale,EstTrandIn", "CarDetailId")
    //        Catch ex As Exception
    //            'Do Nothing
    //        End Try
    //    End If
    //    '############### END CHECK CDLVIS #######################


    //    If IsAdded = False And oCarDetails.vImage = "" Then
    //        dsCarDetail = cCarWeb2.GetVRM(oInitialQuote.RegNo)
    //        'Fail Over
    //        Try
    //            If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //                'do nothing
    //            End If
    //        Catch ex As Exception
    //            dsCarDetail = cCarWeb3.GetVRM(oInitialQuote.RegNo)
    //            Try
    //                If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //                    'do nothing
    //                End If
    //            Catch ex2 As Exception
    //                dsCarDetail = cCarWeb.GetVRM(oInitialQuote.RegNo)
    //                Try
    //                    If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //                        'do nothing
    //                    End If
    //                Catch ex3 As Exception
    //                    dsCarDetail = cCarWebMain.GetVRM(oInitialQuote.RegNo)
    //                    Try
    //                        If dsCarDetail.Tables.Contains("Vehicle") = True Then

    //                        End If
    //                    Catch ex4 As Exception
    //                        'All Failed
    //                    End Try
    //                End Try
    //            End Try
    //        End Try
    //        'Fail Over


    //        Try
    //            If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //                dtCarDetail = dsCarDetail.Tables("Vehicle").Copy()
    //                If dtCarDetail.Rows.Count > 0 Then
    //                    If cCarWeb.IsVehicleAllowed(dtCarDetail.Rows(0)("VehicleCategoryDescription")) Then
    //                        oCarDetails = lCarWeb.UpdateCarDetails(dtCarDetail)
    //                    End If
    //                End If
    //            End If
    //        Catch ex As Exception
    //            Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmNotFound & "&iqid=" & oInitialQuote.InitialQuoteId)  'Fail it as car does not exist
    //            Exit Sub
    //        End Try
    //    End If

    //    'START New Loic , kerbWeightMin update from deflt weight 05-02-2024
    //    If oCarDetails.Exists Then
    //        If oCarDetails.KerbWeightMin = 0 Then
    //            Dim dtDefaultWeightPrices As Data.DataTable = cFunctions.RunQuery("SELECT * FROM tblDefaultWeightPrices where CarModel='" & oCarDetails.Combined_Model & "' And CarMake='" & oCarDetails.Combined_Make & "' ")
    //            If dtDefaultWeightPrices.Rows.Count > 0 Then
    //                Dim rs As DataRow = dtDefaultWeightPrices.Rows(0)

    //                oCarDetails.CarDetailId = oCarDetails.CarDetailId
    //                oCarDetails.KerbWeightMin = Val(rs("Weight"))
    //                oCarDetails.DateUpdated = Date.Now
    //                oCarDetails.Update("KerbWeightMin,DateUpdated", "CarDetailId")

    //                oCarDetails.VRM_Curr = oInitialQuote.RegNo
    //                oCarDetails.LoadByRS(oCarDetails.GetData("*", "VRM_Curr", ""))
    //            End If
    //        End If
    //    End If
    //    'END New Logic

    //    'Copy Image to Local
    //    If oCarDetails.Exists Then
    //        If File.Exists(VehicleImageUrl & lSecurity.GetEncryptedPassword(oCarDetails.VRM_Curr) & ".jpg") = False Then
    //            Dim b1 As Byte()
    //            Dim Status As Boolean = False
    //            Try
    //                b1 = lCarImages.GetBytesFromUrl("https://ws.carwebuk.com" & oCarDetails.VehicleImageUrl.ToString())
    //                If b1.Length = 0 Then
    //                    Status = True
    //                End If
    //            Catch ex As Exception
    //                Status = True
    //            End Try

    //            If Status = False Then
    //                'lCarImages.WriteBytesToFile(Server.MapPath("~/_cdn/ImageUrl/" & lSecurity.GetEncryptedPassword(oCarDetails.VRM_Curr) & ".jpg"), b1) '
    //                lCarImages.WriteBytesToFile(cFunctions.getVal("RMCStoragePath") & "_cdn\ImageUrl\" & lSecurity.GetEncryptedPassword(oCarDetails.VRM_Curr) & ".jpg", b1)
    //                cFunctions.ExecuteStatement("Update tblCarDetails SET vImage='" & lSecurity.GetEncryptedPassword(oCarDetails.VRM_Curr) & ".jpg" & "' Where CarDetailId=" & oCarDetails.CarDetailId)

    //                Dim strUpdate As String = "Update tblCarDetails SET vImage='" & lSecurity.GetEncryptedPassword(oCarDetails.VRM_Curr) & ".jpg" & "' Where RMCCarId=" & oCarDetails.CarDetailId
    //                cFunctions.ExecuteStatementConn(strUpdate, cFunctions.getVal("ScrapCarCompare"))
    //            End If
    //        End If
    //    End If
    //    'Ends here



    //    ''1) Get details from CARWEB
    //    ''2) Check if that record exist in CarDetails table then update that record with new field called "engine code" & "prevous Owners"
    //    ''3) If record does not exist in CarDetails table then need to insert new record into that table

    //    'Dim dsCarDetail As DataSet = cCarWeb.GetVRM(oInitialQuote.RegNo)
    //    'If dsCarDetail.Tables.Contains("Vehicle") = True Then
    //    '    dtCarDetail = dsCarDetail.Tables("Vehicle").Copy()
    //    '    If dtCarDetail.Rows(0).Item("DVLAYearOfManufacture") <> "" Then                    ' 
    //    '        If Smartline.cCarDetailsVRM.GetByVRM(dtCarDetail.Rows(0).Item("VRM_Curr")) = False Then
    //    '            oCarDetails = lCarWeb.InsertCarDetails(dtCarDetail)
    //    '        Else
    //    '            oCarDetails = lCarWeb.UpdateCarDetails(dtCarDetail)
    //    '            If Not oCarDetails.Exists Then
    //    '                Response.Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmNotFound)  'Fail it as car does not exist
    //    '            End If
    //    '        End If
    //    '    End If
    //    'Else
    //    '    Response.Redirect("/quote/fail.aspx?type=" & lCarValue.FailType.VrmNotFound)  'Fail it as car does not exist
    //    'End If
    //End Sub



    }
}