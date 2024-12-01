<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisitorLogs.aspx.cs" Inherits="ShopWebApp.TryIts.VisitorLogs" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Visitor Logs</title>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Title of the page -->
        <h1>Visitor Logs</h1>
        <!-- Description of the purpose of the logs -->
        <p>The following entries have been logged:</p>
        <!-- Literal control to dynamically display the log entries -->
        <asp:Literal ID="ltLogs" runat="server"></asp:Literal>
    </form>
</body>
</html>
