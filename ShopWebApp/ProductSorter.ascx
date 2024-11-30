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
<div>
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