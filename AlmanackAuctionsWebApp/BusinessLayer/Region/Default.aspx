<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="admin_Region_Default"  Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="pageHeading">
        Region Listing</div>
    <br />
    <br />
    <table align="center" cellpadding="3" class="headertable">
        <tr>
            <td class="headertable_left">
                Options</td>
            <td class="headertable_colon">
                :
            </td>
            <td>
                <a class="navbutton" href="form.aspx?i=0&t=0">Add New Region</a>
            </td>
        </tr>
        <tr>
            <td class="headertable_left">
                Filters</td>
            <td class="headertable_colon">
                :
            </td>
            <td>
                <table class="headertable_filtertable">
                    <tr>
                        <td style="width: 200px;">
                            <strong>ID:</strong><br />
                            <asp:TextBox ID="txtID" runat="server" Width="58px"></asp:TextBox>
                            <asp:Button ID="btnFind" runat="server" Text="Find" />
                        </td>
                        <td style="width: 300px;">
                            <strong>Keyword Search:</strong><br />
                            <asp:TextBox ID="txtKeyword" runat="server" Width="150px"></asp:TextBox>
                            <asp:Button ID="btnSearch" runat="server" Text="Filter" />
                        </td>
                        <td>
                            <b>Page Size:</b><br />
                            <asp:DropDownList ID="ddlPageSize2" runat="server" AutoPostBack="true">
                                <asp:ListItem Value="15" Text="15"></asp:ListItem>
                                <asp:ListItem Value="25" Text="25"></asp:ListItem>
                                <asp:ListItem Value="50" Text="50"></asp:ListItem>
                                <asp:ListItem Value="75" Text="75"></asp:ListItem>
                                <asp:ListItem Value="100" Text="100"></asp:ListItem>
                                <asp:ListItem Value="150" Text="150"></asp:ListItem>
                                <asp:ListItem Value="200" Text="200"></asp:ListItem>
                                <asp:ListItem Value="250" Text="250"></asp:ListItem>
                                <asp:ListItem Value="500" Text="500"></asp:ListItem>
                                <asp:ListItem Text="All" Value="1000000"></asp:ListItem>
                            </asp:DropDownList>
                            Rows
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <b>Publish: </b>
                            <asp:DropDownList ID="ddlPublish" runat="server" AutoPostBack="true">
                                <asp:ListItem Text="Both" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Published" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Unpublished" Value="2"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="headertable_left">
                Statistics</td>
            <td class="headertable_colon">
                :
            </td>
            <td>
                <table cellpadding="3">
                    <tr>
                        <td>
                            <b>Total Records : </b>
                            <asp:Label ID="lblTotalCount" runat="server"></asp:Label>
                        </td>
                        <td class="headertable_stat_sep">
                            <b>Published : </b>
                            <asp:Label ID="lblStat1" runat="server"></asp:Label>
                        </td>
                        <td class="headertable_stat_sep">
                            <b>Unpublished : </b>
                            <asp:Label ID="lblStat2" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <div align="center" id="divMessage" runat="server" style="color: Red;">
    </div>
    <br />
    <div align="center">
        <asp:GridView PageSize="50" ID="gvMain" runat="server" SkinID="gridviewSkin" DataKeyNames="RegionId"
            AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" Width="95%"
            CellPadding="4">
            <Columns>
                <asp:TemplateField HeaderText="">
                    <HeaderStyle Width="1%" />
                    <ItemTemplate>
                        <a href="form.aspx?t=1&i=<%#Eval("RegionId")%>">Select</a></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Region Name">
                    <HeaderStyle HorizontalAlign="Left" Width="40%" />
                    <ItemStyle HorizontalAlign="Left" />
                    <ItemTemplate>
                        <%#Eval("RegionName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Country" HeaderText="Country" InsertVisible="False" ReadOnly="True"
                    SortExpression="Country" Visible="false">
                    <ItemStyle HorizontalAlign="left" />
                    <HeaderStyle Width="10%" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Active" SortExpression="Active">
                    <HeaderStyle Width="2%" />
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#IIf(Eval("Active"), "<b>Yes</b>", "No")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Delete">
                    <HeaderStyle Width="3%" />
                    <ItemTemplate>
                        <a href="javascript:callAlert('default.aspx?a=del&i=<%#Eval("RegionId")%>');">
                            <img src="../images/delete.gif" border="0" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    <br />
</asp:Content>
