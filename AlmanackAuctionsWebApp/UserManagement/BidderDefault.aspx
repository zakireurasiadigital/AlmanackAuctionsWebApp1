<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="BidderDefault.aspx.cs" Inherits="AlmanackAuctionsWebApp.UserManagement.BidderDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <style>
        .content-wrapper {
            margin-top: 100px;
        }

        .gridRow,
        .gridAltRow,
        .headerRow {
            border-bottom: 1px solid #ddd;
        }

            .gridRow:last-child,
            .gridAltRow:last-child {
                border-bottom: none;
            }

        .gridCell {
            border-right: 1px solid #ddd;
        }

            .gridCell:last-child {
                border-right: none;
            }

        .filter-input {
            width: 100%;
            padding: 5px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        /* Style for search button */
        .search-btn {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 4px;
            cursor: pointer;
            transition: background-color 0.3s;
        }

            .search-btn:hover {
                background-color: #0056b3;
            }

        .pagination-ys {
            padding-left: 0;
            margin: 20px 0;
            border-radius: 4px;
        }

            .pagination-ys table > tbody > tr > td {
                display: inline;
            }

                .pagination-ys table > tbody > tr > td > a,
                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    color: black; /* Changed color to black */
                    font-weight: 500;
                    background-color: #2c8453;
                    border: 1px solid #dddddd;
                    margin-left: -1px;
                }

                .pagination-ys table > tbody > tr > td > span {
                    position: relative;
                    float: left;
                    padding: 8px 12px;
                    line-height: 1.42857143;
                    text-decoration: none;
                    margin-left: -1px;
                    z-index: 2;
                    color: #aea79f;
                    background-color: #f5f5f5;
                    border-color: #dddddd;
                    cursor: default;
                }

                .pagination-ys table > tbody > tr > td:first-child > a,
                .pagination-ys table > tbody > tr > td:first-child > span {
                    margin-left: 0;
                    border-bottom-left-radius: 4px;
                    border-top-left-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td:last-child > a,
                .pagination-ys table > tbody > tr > td:last-child > span {
                    border-bottom-right-radius: 4px;
                    border-top-right-radius: 4px;
                }

                .pagination-ys table > tbody > tr > td > a:hover,
                .pagination-ys table > tbody > tr > td > span:hover,
                .pagination-ys table > tbody > tr > td > a:focus,
                .pagination-ys table > tbody > tr > td > span:focus {
                    color: #97310e;
                    background-color: #eeeeee;
                    border-color: #dddddd;
                }

        tbody a {
            color: #fff !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <div class="pageHeading">
            User Management
        </div>
        <br />
        <div class="container">
            <div class="row">
                <div class="col-md-4">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search..."></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:Button ID="btnSearch" runat="server" CssClass="search-btn" Text="Search" OnClick="btnSearch_Click" />
                </div>
                <div class="col-md-2">
                    <div class="input-group">
                        <div class="input-group-prepend">
                            <span class="input-group-text">Page Size:</span>
                        </div>
                        <asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" CssClass="form-control" AutoPostBack="true">
                            <asp:ListItem Value="20">20</asp:ListItem>
                            <asp:ListItem Value="30">30</asp:ListItem>
                            <asp:ListItem Value="40">40</asp:ListItem>
                            <asp:ListItem Value="50">50</asp:ListItem>
                            <asp:ListItem Value="100">100</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

            </div>
            <br />
            <ul class="nav nav-tabs" id="myTabs" role="tablist">
                <li class="nav-item">
                    <a class="nav-link active" id="add-region-tab" data-bs-toggle="tab" href="#add-region" role="tab" aria-controls="add-region" aria-selected="true">Options</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" id="add-user-tab" data-bs-toggle="tab" href="BiddersForm.aspx?i=0&t=0" role="tab" aria-controls="add-user" aria-selected="false">Add Agent Bidder</a>
                </li>
            </ul>
        </div>
        <div align="center">
            <asp:GridView PageSize="50" ID="gvMain" HeaderStyle-BackColor="SeaGreen" OnSorting="gvMain_Sorting" HeaderStyle-HorizontalAlign="Center" OnPageIndexChanging="gvMain_PageIndexChanging" HeaderStyle-ForeColor="White" runat="server" class="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="UserID"
                AllowPaging="True" AllowSorting="True" Width="95%">
                <Columns>
                    <asp:BoundField DataField="UserID" HeaderText="UserID" Visible="false" />
                    <asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="UserName" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="CompanyName" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Postcode" HeaderText="Post Code" SortExpression="Postcode" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Status" HeaderText="Active" SortExpression="Status" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="DateAdded" HeaderText="Created On" DataFormatString="{0:dd/MM/yyyy}" SortExpression="DateAdded" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbtnEdit" PostBackUrl='<%# Eval("UserID", "~/UserManagement/BiddersForm_edit.aspx?i={0}") %>' runat="server">
                    <i class="fas fa-pencil-alt" style="color: seagreen;" title="Click here to edit" ></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Change Password" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnChangePassword" PostBackUrl='<%# Eval("UserID", "~/UserManagement/ChangePassword.aspx?i={0}&UserType=Bidder") %>' runat="server">
 <i class="fas fa-key" style="color: seagreen;" title="Click here to Change Password" ></i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Mode="Numeric" FirstPageText="First" LastPageText="Last" Position="Bottom" />
                <PagerStyle HorizontalAlign="Right" CssClass="pagination-ys" />
                <HeaderStyle CssClass="header"></HeaderStyle>
                <RowStyle CssClass="rows"></RowStyle>
            </asp:GridView>

        </div>
        <br />
    </div>
</asp:Content>

