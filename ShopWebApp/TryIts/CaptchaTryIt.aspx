<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaptchaTryIt.aspx.cs" Inherits="ShopWebApp.TryIts.CaptchaTryIt" %>
<%@ Register TagPrefix="user" TagName="captcha" Src="~/Captcha.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Captcha Try It</h1>
            <!-- Dummy Form -->
            <p>This user control validates if the user is human.</p>
            <h2>How to use it:</h2>
            <ul>
                <li>Log in with valid credentials. Username: member, Password: member123.</li>
                <li>Click Captcha.</li>
                <li>Hit log in button.</li>
            </ul>
            <div>
                <asp:Label ID="usernameLabel" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="username" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="passwordLabel" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="password" runat="server"></asp:TextBox>
            </div>
            <user:captcha runat="server" ID="captcha" />
            <div>
                <asp:Button ID="submit" runat="server" Text="Log In" OnClick="submit_Click" />
            </div>
            <div>
                <asp:Label ID="Result" runat="server" Text=" "></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
