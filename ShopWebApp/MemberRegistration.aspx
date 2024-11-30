<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegistration.aspx.cs" Inherits="Assignment6.ShopWebApp.MemberRegistration" %>
<%@ Register TagPrefix="user" TagName="captcha" Src="~/Captcha.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Member Registration Page</h1>
        <div>
            Username: 
            <asp:TextBox ID="UserNameField" runat="server"></asp:TextBox>
            <asp:Label ID="UsernameErr" runat="server" Text=""></asp:Label>
        </div>
        <div>
            Password: <asp:TextBox ID="PasswordField" runat="server"></asp:TextBox>
        </div>
        <div>
            <user:captcha runat="server" ID="captcha" />
            <asp:Label ID="CaptchaErr" runat="server" Text=""></asp:Label>
        </div>
        <div>
            <asp:Button ID="CreateBtn" runat="server" Text="Create Account" OnClick="validateFormEntry" />
        </div>
    </form>
</body>
</html>

