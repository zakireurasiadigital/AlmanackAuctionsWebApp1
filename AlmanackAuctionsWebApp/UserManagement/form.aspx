<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="AlmanackAuctionsWebApp.UserManagement.form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Custom styles */
        .content-wrapper {
            margin-top: 20px;
        }

        .form-group {
            margin-bottom: 20px;
        }

            .form-group label {
                display: block;
                margin-bottom: 5px;
                font-weight: bold;
            }

        .form-control {
            width: 100%;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
            transition: border-color 0.3s;
        }

            .form-control:focus {
                border-color: #007bff;
                outline: none;
            }

        .btn-group {
            margin-top: 20px;
            text-align: right;
        }

        .btn {
            padding: 12px 24px;
            border: none;
            border-radius: 7px !important;
            cursor: pointer;
            transition: background-color 0.3s, color 0.3s;
            font-size: 16px;
            font-weight: bold;
            letter-spacing: 1px;
        }

        .btn-save {
            background-color: #28a745;
            color: white;
            margin-right: 20px;
        }

        .btn-cancel {
            background-color: #dc3545;
            color: white;
        }

        .btn:hover {
            opacity: 0.8;
            color: #fff;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content-wrapper">
        <section class="hero-bg">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-8">

                        <div align="center" runat="server" id="pagetitle" class="pageHeading">
                            User Information
                        </div>
                        <br />
                        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                        <!-- Form -->
                        <div class="form-wrapper">
                            <div class="form-group row">
                                <div class="col-md-6">
                                    <label for="txtUserName">User Name</label>
                                    <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name" CssClass="form-control"></asp:TextBox>
                                </div>
                                 <div class="col-md-6" id="DivPassWord" runat="server" visible="true">
                                    <label for="txtPassword">Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-6" id="DivCompnayName" runat="server" visible="true">
                                    <label for="lblCompanyName">Company Name</label>
                                    <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Company Name" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="lblFirstName">First Name</label>
                                    <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtLastName">Last Name</label>
                                        <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtAddress">Address</label>
                                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Address" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label for="txtPostCode">Post Code</label>
                                        <asp:TextBox ID="txtPostCode" runat="server" placeholder="Post Code" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                 <div class="col-md-6" id="DivEmail" runat="server" visible="true">
                                    <div class="form-group">
                                        <label for="txtPostCode">Email </label>
                                        <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                                    <div class="form-group" id="DivIsActive" runat="server" visible="false">
                                        <label for="txtPostCode">Is Active?</label>
                                        <asp:CheckBox ID="chkIsActive" runat="server"></asp:CheckBox>
                                    </div>
                            <!-- Buttons -->
                            <div class="btn-group" style="margin-top: 5px;">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-save" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-cancel" />
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>