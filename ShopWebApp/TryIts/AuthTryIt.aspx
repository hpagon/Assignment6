<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthTryIt.aspx.cs" Inherits="ShopWebApp.TryIts.AuthTryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ToDefaultBtn" runat="server" Text="Back to Default page" OnClick="ToDefaultBtn_Click" />
        <h1>DLL Component</h1>
        <h2>MyAuthenticateDLL</h2>
        <h3>Test cases</h3>
        <ol>
            <li>Enter username = <b>TestMember</b>, password = <strong>Password </strong>, 
                File path = <b>~/App_Data/Member.xml</b>, Expected: <strong>Success</strong></li>
            <li>Enter username = <b>TestStaff</b>, password = <strong>StaffPassword </strong>, 
                File path = <b>~/App_Data/Staff.xml</b>, Expected: <strong>Success</strong></li>
            <li>Enter username = <strong>TestStaff</strong>, password = <strong>StaffPassword</strong>, 
                File path = <b>~/App_Data/FakeFile.xml</b>, Expected: <strong>Error reading file</strong></li>
            <li>Enter username = <strong>TestStaff</strong>, password = <strong>FakePassword</strong>, File path = <strong>~/App_Data/Staff.xml</strong>, Expected: <strong>Invalid Username or Password</strong></li>
            <li>Enter username = <strong>FakeName</strong>, password = <strong>StaffPassword</strong>, File path = <strong>~/App_Data/Staff.xml&nbsp; </strong>Expected: <strong>Invalid Username or Password</strong></li>
            <li>Enter username = <strong>(leave blank)</strong>, password = <strong>StaffPassword</strong>, File path = <strong>~/App_Data/Staff.xml,</strong>&nbsp;Expected: <strong>Please enter username </strong>
            </li>
            <li>Enter username = <strong>TestStaff</strong>, password = <strong>(leave blank),</strong> File path = <strong>~/App_Data/Staff.xml,</strong> Expected: <strong>Please enter password </strong>
            </li>
            <li>Enter username = <strong>TestStaff</strong>, password = <strong>StaffPassword</strong>, File path = <strong>(leave blank),</strong> Expected: <strong>Please enter file path </strong>
            </li>
        </ol>
        <div>
            Username: <asp:TextBox ID="UserField" runat="server"></asp:TextBox>
        </div>
        <div>
            Password: <asp:TextBox ID="PasswordField" runat="server"></asp:TextBox>
        </div>
        <div>
            File path: <asp:TextBox ID="FileField" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="SubmitBtn" runat="server" Text="Submit" OnClick="SubmitBtn_Click" style="height: 29px" />
        </div>
        <div>
            <asp:Label ID="Output" runat="server" Text=""></asp:Label></div>
    </form>
</body>
</html>
