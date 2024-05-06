<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AlmanackAuctionsWebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color: #f5f5f5;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .login-container {
            background-color: #fff;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 40px;
            width: 300px;
            text-align: center;
            position: relative; 
        }

        .login-container h2 {
            margin-bottom: 20px;
            color: #333;
        }

        .login-container input[type="text"],
        .login-container input[type="password"],
        .login-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .login-container input[type="submit"] {
            background-color: #4CAF50;
            color: white;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s;
        }

        .login-container input[type="submit"]:hover {
            background-color: #45a049;
        }

        .logo {
            max-width: 150px;
            margin: 0 auto 20px; 
            display: block; 
        }

        .password-toggle {
            display: inline-block;
            position: absolute;
            top: 64%;
            right: 44px;
            transform: translateY(-50%);
            cursor: pointer;
            color: #888;
        }

        .password-toggle:hover {
            color: #333;
        }
         .error-message {
        color: #ff0000; 
        font-size: 14px;
        margin-top: 5px; 
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
             <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message" Visible="false"></asp:Label>
            <img src="images/logo.png" alt="Logo" class="logo" />
            <h2>Login</h2>
            <asp:TextBox runat="server" ID="txtUsername" placeholder="Username *" />
            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" placeholder="Password *" />
            <span class="password-toggle" onclick="togglePassword()"><i class="far fa-eye"></i></span>
            <asp:Button runat="server" ID="btnLogin" Text="Login" OnClick="btnLogin_Click" />
            <asp:HyperLink runat="server" ID="lnkForgotPassword" NavigateUrl="ForgotPassword.aspx" Text="Forgot Password?" />
        </div>
    </form>
    <script>
        function togglePassword() {
            var passwordField = document.getElementById('<%= txtPassword.ClientID %>');
            if (passwordField.type === "password") {
                passwordField.type = "text";
                document.querySelector('.password-toggle i').classList.remove('fa-eye');
                document.querySelector('.password-toggle i').classList.add('fa-eye-slash');
            } else {
                passwordField.type = "password";
                document.querySelector('.password-toggle i').classList.remove('fa-eye-slash');
                document.querySelector('.password-toggle i').classList.add('fa-eye');
            }
        }
    </script>
    <script>
        function showToast(type, message) {
            toastr.options = {
                closeButton: true,
                progressBar: true,
                positionClass: 'toast-top-right',
                preventDuplicates: true,
                timeOut: 3000 // 3 seconds
            };
            toastr[type](message);
        }
    </script>
</body>
</html>
