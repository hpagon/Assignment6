<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartTryIt.aspx.cs" Inherits="ShopWebApp.TryIts.ShoppingCartTryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Shopping Cart TryIt</h1>
            <p>This page is used to show the functionality of the save shopping cart local component and complete transaction service.</p>
            <h2>How to use it:</h2>
            <ul>
                <li>Save Shopping Cart Local Component (Session State):
                    <ul>
                        <li>This local component implements session state to save the shopping cart within the same session.</li>
                        <li>To try it, add items from the catalog into the shopping cart.</li>
                        <li>Refresh the page to see the same shopping cart intact.</li>
                    </ul>
                </li>
                <li>Complete Transaction Service:
                    <ul>
                        <li>This page calls the complete transaction service when a user clicks the checkout button.</li>
                        <li>The service processes the order and returns the updated stock levels of the inventory.</li>
                        <li>To test, just checkout a shopping cart with items and watch the stock levels update.</li>
                    </ul>
                </li>
            </ul>
            <h2>Item Catalog</h2>
            <div class="catalog">
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
                    <asp:Button ID="addToCart" runat="server" Text="Add to Cart" OnClick="addToCart_Click" />
                    <asp:Label ID="catalogLabel" runat="server" Text=" "></asp:Label>
                </div>
            </div>
            <h2>Shopping Cart</h2>
            <div class="shoppingCartContainer" border="1">
                <asp:ListBox ID="shoppingCart" runat="server" Width="80%"></asp:ListBox>
                <div class="shoppingCartControls">
                    <asp:Button ID="remove" runat="server" Text="Remove From Cart" OnClick="remove_Click" />
                    <asp:Button ID="checkout" runat="server" Text="Checkout" OnClick="checkout_Click" style="height: 29px" />
                    <asp:Label ID="shoppingCartLabel" runat="server" Text=" "></asp:Label>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
