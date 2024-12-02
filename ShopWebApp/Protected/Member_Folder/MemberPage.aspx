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
                    <asp:Button ID="addToCart" runat="server" Text="Add to Cart" OnClick="addToCart_Click"/>
                    <asp:Label ID="catalogLabel" runat="server" Text=" "></asp:Label>
                </div>
            </div>
           <div class="recommendationContainer">
               <h3>Not Sure what to get? Try our product recommendation tool!</h3>
               <div class="recommendationControls">
                   <asp:DropDownList ID="categories" runat="server">
                       <asp:ListItem Text="Electronics" value="electronics"/>
                       <asp:ListItem Text="Books" value="books"/>
                       <asp:ListItem Text="Fashion" value="fashion"/>
                       <asp:ListItem Text="Home" value="home"/>
                       <asp:ListItem Text="Toys" value="toys"/>
                       <asp:ListItem Text="Sports" value="sports"/>
                   </asp:DropDownList>
                   <asp:DropDownList ID="priceRanges" runat="server">
                       <asp:ListItem Text="Low" value="low"/>
                       <asp:ListItem Text="High" value="high"/>
                   </asp:DropDownList>
                   <asp:Button ID="recommendationsButton" runat="server" Text="Get Recommendations" OnClick="recommendationsButton_Click" />
                   <asp:Button ID="hideRecommendations" runat="server" Text="Reset" OnClick="hideRecommendations_Click"/>
               </div>
           </div>
       </div>
       <div>
            <h2>Shopping Cart</h2>
            <asp:ListBox ID="shoppingCart" runat="server" Width="80%"></asp:ListBox>
            <div class="shoppingCartControls">
                <asp:Button ID="remove" runat="server" Text="Remove From Cart" OnClick="remove_Click" />
                <asp:Button ID="checkout" runat="server" Text="Checkout" style="height: 29px" OnClick="checkout_Click" />
                <asp:Label ID="shoppingCartLabel" runat="server" Text=" "></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
