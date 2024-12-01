<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductSorter.ascx.cs" Inherits="ShopWebApp.Controls.ProductSorter" %>
<div class="product-sorter">
    <div>You must click the Display results button at least once to see the product list.</div>
    <div>
   Sort by: <asp:DropDownList ID="DropDownList1" runat="server">
       <asp:ListItem Text="Price: Low-to-high" Value="1"></asp:ListItem>
       <asp:ListItem Text="Price: High-to-low" Value="2"></asp:ListItem>
       <asp:ListItem Text="Best ratings" Value="3"></asp:ListItem>
            </asp:DropDownList>
    <asp:Button ID="SortBtn" runat="server" Text="Display results" OnClick="SortBtn_Click" />
</div>
<%-- Product List For Try It --%>
<div runat="server" ID="TryItContainer">
    <ol>
        <li><asp:Label ID="Prod1" runat="server" Text=""></asp:Label></li>
        <li>
            <asp:Label ID="Prod2" runat="server" Text=""></asp:Label></li>
        <li>
            <asp:Label ID="Prod3" runat="server" Text=""></asp:Label></li>
        <li>
            <asp:Label ID="Prod4" runat="server" Text=""></asp:Label></li>
        <li>
            <asp:Label ID="Prod5" runat="server" Text=""></asp:Label></li>
    </ol>
</div>
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
