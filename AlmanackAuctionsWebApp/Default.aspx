<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AlmanackAuctionsWebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .content-wrapper {
            display: flex;
            flex-direction: column;
            align-items: center;
            margin-top: 20px;
        }

        .button-container {
            display: flex;
            justify-content: space-between;
            width: 100%;
            max-width: 400px;
            margin-top: 20px;
        }

            .button-container .btn {
                flex: 1;
                margin: 5px;
                width: auto;
                transition: background-color 0.3s;
            }

                .button-container .btn:hover {
                    filter: brightness(90%);
                }

        .content-wrapper h1 {
            margin-top: 80px;
        }

        @media screen and (max-width: 768px) {
            .button-container {
                flex-direction: column;
                align-items: center;
            }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Heading -->
    <div class="content-wrapper">
        <h1>Admin Home Page</h1>

        <!-- Buttons inside a div -->
        <div class="button-container">
            <asp:Button ID="btnListings" runat="server" Text="Listings" OnClick="btnListings_Click" CssClass="btn btn-msg" />
            <asp:Button ID="btnUsers" runat="server" Text="Users" OnClick="btnUsers_Click" CssClass="btn btn-sell" />
            <asp:Button ID="btnAdminUsers" runat="server" OnClick="btnAdminUsers_Click" Text="Admin Agent Users" CssClass="btn btn-review" />
        </div>

          <div style="vertical-align: top; height: 400px; overflow: auto; width: 100%;">
          </div>
    </div>
</asp:Content>
