<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false"
    CodeFile="form.aspx.vb" Inherits="admin_Region_form" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="hero-bg">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-12">

                    <div align="center" runat="server" id="pagetitle" class="pageHeading">
                        Modify Region Information
                    </div>
                    <br />
                    <table class="tables_table" cellpadding="0" cellspacing="0" border="0" width="95%"
                        align="center">
                        <%If Request.QueryString("t") = "1" Then%>
                        <tr>
                            <td class="tables_2ndheadercell" valign="top" nowrap style="width: 125px">Region Id</td>
                            <td width="80%" class="tables_contentcell">
                                <asp:TextBox ID="txtRegionId" runat="server" ReadOnly="true" Width="70px"></asp:TextBox>
                            </td>
                        </tr>
                        <%End If%>
                        <tr style="display: none;">
                            <td class="tables_2ndheadercell" valign="top" nowrap style="width: 125px">Country</td>
                            <td width="80%" class="tables_contentcell">
                                <asp:DropDownList runat="server" ID="ddlCountries">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="tables_2ndheadercell" valign="top" nowrap style="width: 125px">Region Name</td>
                            <td width="80%" class="tables_contentcell">
                                <asp:TextBox ID="txtRegionName" runat="server" Width="250px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID='rfvRegionName' runat='server' ControlToValidate='txtRegionName'>* Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tables_2ndheadercell" valign="top" nowrap style="width: 125px">Page Url</td>
                            <td width="80%" class="tables_contentcell">
                                <asp:TextBox ID="txtPageUrl" runat="server" Width="550px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID='RequiredFieldValidator1' runat='server' ControlToValidate='txtPageUrl'>* Required</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tables_2ndheadercell" valign="top" nowrap style="width: 125px">Active</td>
                            <td width="80%" class="tables_contentcell">
                                <asp:CheckBox ID="chkActive" runat="server"></asp:CheckBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="tables_contentcell" style="height: 30px; width: 125px;">
                                <asp:Button ID="btnDelete" runat="server" class="formbutton" Text="Delete" CausesValidation="False" />
                            </td>
                            <td class="tables_contentcell" align="right" style="height: 30px">
                                <asp:Button ID="btnUpdate" runat="server" class="formbutton" Text="      Save      " />
                                <asp:Button ID="btnCancel" runat="server" class="formbutton" Text="Cancel" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
