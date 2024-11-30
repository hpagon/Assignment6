<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment6.ShopWebApp.Login" %>
<%@ Import Namespace="PasswordLibrary" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Member Login Section -->
        <div>
            <h1>Member Login</h1>
            <h2>Username = TestMember and Password = Password</h2>
            <label>Enter Username:</label>
            <asp:TextBox ID="MemberNameField" runat="server"></asp:TextBox><br />
            <label>Enter Password:</label>
            <asp:TextBox ID="MemberPwdField" runat="server"></asp:TextBox><br />
            <asp:Button ID="MemberSubmitBtn" runat="server" Text="Member Login" OnClick="MemberLoginFunc" />
            <asp:CheckBox ID="MemberPersistent" runat="server" Text="Remember me" /><br />
            <asp:Label ID="MemberErrOutput" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
        <hr />
        <!-- Staff Login Section -->
        <div>
            <h1>Staff Login</h1>
            <h2>Username = TA and Password = Cse445!</h2>
            <label>Enter Username:</label>
            <asp:TextBox ID="StaffNameField" runat="server"></asp:TextBox><br />
            <label>Enter Password:</label>
            <asp:TextBox ID="StaffPwdField" runat="server"></asp:TextBox><br />
            <asp:Button ID="StaffSubmitBtn" runat="server" Text="Staff Login" OnClick="StaffLoginFunc" />
            <asp:CheckBox ID="StaffPersistent" runat="server" Text="Remember me" /><br />
            <asp:Label ID="StaffErrOutput" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
