<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberPage.aspx.cs" Inherits="Assignment6.ShopWebApp.Protected.Member_Folder.MemberPage" %>
<%@ Register TagPrefix="uc" TagName="ProductSorter" Src="~/ProductSorter.ascx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="form1" runat="server">
        <h1>Welcome to the Member Page, <asp:Label ID="memberNameLabel" runat="server" Text="User"></asp:Label>!</h1>
        <asp:Button ID="LogoutButton" runat="server" Text="Logout" OnClick="LogoutButton_Click" />
       <div>
           <h2>Product Catalog</h2>
           <uc:ProductSorter runat="server" ID="ProductSorterControl" PageContext="MemberPage" />
       </div>
       <div>
            <h2>Shopping Cart</h2>
            <uc:ProductSorter runat="server" ID="ProductSorter1" PageContext="MemberPage" />
        </div>
    </form>
</body>
</html>
