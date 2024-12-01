<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment6.ShopWebApp.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Store</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="MemberRegister" runat="server" Text="Member Register" PostBackUrl="~/MemberRegistration.aspx" />

            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="MemberLogin" runat="server" Text="Member Login" PostBackUrl="~/Login.aspx"/>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="MemberPage" runat="server" Text="Member Page" PostBackUrl="~/Protected/Member_Folder/MemberPage.aspx"/>
        </div>
        <div>
            <asp:Button ID="StaffLogin" runat="server" Text="Staff Login" PostBackUrl="~/StaffLogin.aspx" />
            &nbsp;&nbsp;&nbsp
            <asp:Button ID="StaffPage" runat="server" Text="Staff Page" PostBackUrl="~/Protected/Member_Folder/StaffPage.aspx"/>
 
        </div>

        <h2>Service Directory</h2>
        <div>
            <table style="width: 100%;" border="1">
                <tr>
                    <td>Contribution</td>
                    <td> Heber 33.3%</td>
                    <td> Noah 33.3%</td>
                    <td> Rachel 33.3%</td>
                </tr>
                <tr>
                    <td><b>Provider Name</b></td>
                    <td><b>Component Type</b></td>
                    <td><b>Operation Name</b></td>
                    <td><b>Parameters</b></td>
                    <td><b>Return type</b></td>
                    <td><b>Function</b></td>
                    <td><b>TryIt</b></td>
                </tr>
                <tr>
                    <td>Rachel</td>
                    <td>DLL</td>
                    <td>myAuthenticate</td>
                    <td>strings usernameInfo, passwordInfo, file</td>
                    <td>bool</td>
                    <td>Compares the username/password combo to the xml userfile</td>
                    <td><asp:HyperLink ID="DLLLink" runat="server" NavigateUrl="~/TryIts/AuthTryIt.aspx">TryIt</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>Rachel</td>
                    <td>User Control</td>
                    <td>Page Load, SortBtn_Click, UpdateList</td>
                    <td>None, the products are hard coded in</td>
                    <td>Void (it updates the list of products shown on the webpage)</td>
                    <td>User control that lets members choose to sort by price(low-to-high or high-to-low) or by best ratings</td>
                    <td><asp:HyperLink ID="HyperLink1" NavigateUrl="~/TryIts/ProductSorterTryIt.aspx" runat="server">TryIt</asp:HyperLink></td>
                </tr>
                <tr>
                    <td>Rachel</td>
                    <td>Member Registration Web Form</td>
                    <td>Coded the aspx and aspx.cs</td>
                </tr>
                <tr>
                    <td>Rachel</td>
                    <td>Member and staff login page</td>
                    <td>Coded the aspx and aspx.cs</td>
                </tr>
                <tr>
                    <td>Heber Pacheco Aragon</td>
                    <td>User Control</td>
                    <td>Captcha</td>
                    <td>N/A</td>
                    <td>N/A</td>
                    <td>Verifies if the user is human.</td>
                    <td>
                        <a href="./TryIts/CaptchaTryIt.aspx">TryIt</a>
                     </td>
                </tr>
                <tr>
                    <td>Heber Pacheco Aragon</td>
                    <td>Session State</td>
                    <td>Save Shopping Cart</td>
                    <td>N/A</td>
                    <td>N/A</td>
                    <td>Saves the items in the users shopping cart to the current session.</td>
                    <td><a href="./TryIts/ShoppingCartTryIt.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Heber Pacheco Aragon</td>
                    <td>WSDL Service</td>
                    <td>Complete Transaction</td>
                    <td>List&lt;Dictionary&lt;String,String&gt;&gt;</td>
                    <td>Dictionary&lt;String,String&gt;</td>
                    <td>Processes order and updates stock levels based on the users shopping cart. Since I haven't deployed this service yet, please run the localhost in order to test it. The service can be found under the checkout project.</td>
                    <td><a href="./TryIts/ShoppingCartTryIt.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Noah</td>
                    <td>DLL Function</td>
                    <td>HashPassword</td>
                    <td>password (string)</td>
                    <td>string (hashed password)</td>
                    <td>Hashes and encrypts user passwords securely</td>
                    <td><a href="./TryIts/PasswordHashTryIt.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Noah</td>
                    <td>Cookie</td>
                    <td>SaveCookie, ShowCookie</td>
                    <td>None</td>
                    <td>string (cookie value)</td>
                    <td>Stores user preferences in temporary cookies</td>
                    <td><a href="./TryIts/CookieTryIt.aspx">TryIt</a></td>
                </tr>
                <tr>
                    <td>Noah</td>
                    <td>Global.asax Event Handler</td>
                    <td>N/A</td>
                    <td>N/A</td>
                    <td>N/A</td>
                    <td>Logs application start events and page visits</td>
                    <td><a href="./TryIts/ShoppingCartTryIt.aspx">TryIt</a></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>