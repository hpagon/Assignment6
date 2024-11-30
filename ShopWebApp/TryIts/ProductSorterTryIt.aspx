<%@ Register TagPrefix="uc" TagName="ProductSorter" Src="~/ProductSorter.ascx" %>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductSorterTryIt.aspx.cs" Inherits="ShopWebApp.TryIts.TryItSortUserControl" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Try-It: Product Sorter</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="ToDefaultBtn" runat="server" Text="Back to Default Page" OnClick="ToDefaultBtn_Click" />
        <h1>Try-It: Product Sorter</h1>
        <h3>Embedded ProductSorter User Control</h3>
        <div>
            <uc:ProductSorter ID="ProductSorterControl" runat="server" />
        </div>
    </form>
</body>
</html>

