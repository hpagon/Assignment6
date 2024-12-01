<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookieTryIt.aspx.cs" Inherits="ShopWebApp.TryIts.CookieTryIt" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cookie Management TryIt</title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Cookie Management TryIt Page</h1>
        <p>This page demonstrates saving, retrieving, and clearing cookies with multiple attributes.</p>

        <h2>Instructions</h2>
        <p>Use the buttons below to test cookie functionality:</p>
        <ul>
            <li><strong>Save Cookie:</strong> Saves a cookie with ProductName, Category, and Timestamp.</li>
            <li><strong>Show Cookie:</strong> Retrieves and displays the saved cookie attributes.</li>
            <li><strong>Clear Cookie:</strong> Deletes the saved cookie.</li>
        </ul>

        <p>
            <asp:Button ID="btnSaveCookie" runat="server" Text="Save Cookie" OnClick="SaveCookie_Click" />
            <asp:Button ID="btnShowCookie" runat="server" Text="Show Cookie" OnClick="ShowCookie_Click" />
            <asp:Button ID="btnClearCookie" runat="server" Text="Clear Cookie" OnClick="ClearCookie_Click" />
        </p>
        <p>
            <asp:Label ID="lblCookieOutput" runat="server" Text="" ForeColor="Green"></asp:Label>
        </p>
    </form>
</body>
</html>
