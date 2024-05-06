Imports System.Data
Partial Class admin_Region_form
    Inherits System.Web.UI.Page

    Dim SaveType As Integer
    Dim RegionId As Integer
    Dim dtRegion As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SaveType = Request.QueryString("t")
        RegionId = Request.QueryString("i")

        If Not Page.IsPostBack Then

        End If

    End Sub


End Class
