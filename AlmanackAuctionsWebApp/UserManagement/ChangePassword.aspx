<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="AlmanackAuctionsWebApp.UserManagement.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">
    <style>
        .eye-icon {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Modal -->
    <asp:Panel ID="Panel1" runat="server" CssClass="modal fade" TabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <!-- Modal content -->
    </asp:Panel>
    <div class="modal fade" id="passwordChangeModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Change Password</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="newPassword">New Password</label>
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtNewPassword" CssClass="form-control" placeholder="Enter New Password *" />
                            <div class="input-group-append">
                                <span class="input-group-text eye-icon" onclick="togglePasswordVisibility('<%= txtNewPassword.ClientID %>')">
                                    <i class="fas fa-eye"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="confirmPassword">Confirm Password</label>
                        <div class="input-group">
                            <asp:TextBox runat="server" ID="txtConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirm New Password" />
                            <div class="input-group-append">
                                <span class="input-group-text eye-icon" onclick="togglePasswordVisibility('<%= txtConfirmPassword.ClientID %>')">
                                    <i class="fas fa-eye"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="modal-footer">
                    <asp:Button ID="btnCloseModal" runat="server" Text="Close" CssClass="btn btn-secondary" OnClick="btnCloseModal_Click" Style="background-color: #6c757d; border-color: #6c757d;" />
                    <asp:Button ID="btnSaveChanges" runat="server" Text="Save" CssClass="btn btn-secondary" OnClick="btnSaveChanges_Click" Style="background-color: #007bff; border-color: #007bff;" />
                </div>

            </div>
        </div>
    </div>

    <!-- Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            $('#passwordChangeModal').modal('show');
        });

        function changePassword() {
            var newPassword = document.getElementById('newPassword').value;
            var confirmPassword = document.getElementById('confirmPassword').value;

            if (newPassword !== confirmPassword) {
                alert("Passwords do not match!");
                return;
            }

            console.log("New Password:", newPassword);

            document.getElementById('newPassword').value = '';
            document.getElementById('confirmPassword').value = '';

            // Close the modal
            $('#passwordChangeModal').modal('hide');
        }

        function togglePasswordVisibility(inputId) {
            var passwordField = document.getElementById(inputId);
            var icon = document.querySelector('#' + inputId + '+ .input-group-append .eye-icon i');

            if (passwordField.type === "password") {
                passwordField.type = "text";
                icon.classList.remove('fa-eye');
                icon.classList.add('fa-eye-slash');
            } else {
                passwordField.type = "password";
                icon.classList.remove('fa-eye-slash');
                icon.classList.add('fa-eye');
            }
        }
    </script>


</asp:Content>