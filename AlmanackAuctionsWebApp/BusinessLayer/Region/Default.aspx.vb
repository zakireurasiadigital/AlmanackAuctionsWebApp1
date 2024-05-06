Imports System.Data

Partial Class admin_Region_Default
    Inherits System.Web.UI.Page
    Dim dtData As DataTable
    Dim searchKeywords As String = "RegionId;RegionId"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        FillGrid()
        If Not IsPostBack Then
            If Request.QueryString("msg") <> "" Then
                divMessage.InnerHtml = Request.QueryString("msg")
            End If
        End If
    End Sub

    Protected Sub gvMain_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs) Handles gvMain.Sorting
        Dim dataTable As System.Data.DataTable = gvMain.DataSource
        If Not (dataTable Is Nothing) Then
            Dim dataView As System.Data.DataView = New System.Data.DataView(dataTable)
            dataView.Sort = e.SortExpression + " ASC"
            gvMain.DataSource = dataView.ToTable
            gvMain.DataBind()
        End If
    End Sub

    Protected Sub gvMain_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs) Handles gvMain.PageIndexChanging
        gvMain.PageIndex = e.NewPageIndex
        FillGrid()
        divMessage.InnerHtml = ""
    End Sub

    Protected Sub FillGrid()


    End Sub

    Protected Sub SetStatistics(ByVal TotalRecords As Integer, ByVal Stat1 As Integer, ByVal stat2 As Integer)
        lblTotalCount.Text = TotalRecords.ToString
        lblStat1.Text = Stat1.ToString
        lblStat2.Text = stat2.ToString
    End Sub

    Protected Sub btnFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFind.Click
        Page.Response.Redirect("Form.aspx?t=1&i=" & txtID.Text)
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        FillGrid()
    End Sub

    Protected Sub ddlPublish_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPublish.SelectedIndexChanged
        FillGrid()
    End Sub
End Class
