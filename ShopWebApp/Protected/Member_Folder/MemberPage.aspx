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
            <%-- Product List for Member Page --%>
            <div runat="server" ID="MemberPageContainer" >
                <table width="80%" id="items-table">
                <tr>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Left in Stock</th>
                    <th>Add to Cart</th>
                </tr>
                </table>
                <asp:ListBox ID="itemCatalog" runat="server" Width="80%"></asp:ListBox>
                <div>
                    <asp:Button ID="addToCart" runat="server" Text="Add to Cart"/>
                    <asp:Label ID="catalogLabel" runat="server" Text=" "></asp:Label>
                </div>
            </div>
       </div>
       <div>
            <h2>Shopping Cart</h2>
        </div>
    </form>
</body>
</html>
