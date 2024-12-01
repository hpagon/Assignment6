<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PasswordHashTryIt.aspx.cs" Inherits="ShopWebApp.TryIts.PasswordHashTryIt" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Password Hashing TryIt</title>
</head>
<body>
    <!-- Main form for the Password Hashing TryIt functionality -->
    <form id="form1" runat="server">
        <!-- Page Title -->
        <h1>Password Hashing TryIt Page</h1>
        <p>This page demonstrates the hashing functionality of the Password Encryption Library (DLL).</p>

        <!-- Instructions Section -->
        <h2>Instructions</h2>
        <p>Enter a password below to hash it using the library. Test cases you can try:</p>
        <ul>
            <!-- Test cases for input -->
            <li>Test Case 1: password = <strong>MySecurePassword</strong></li>
            <li>Test Case 2: password = <strong>Password123</strong></li>
            <li>Test Case 3: password = <strong>Admin!@#</strong></li>
        </ul>

        <!-- Input Section -->
        <p>
            <label for="txtPassword">Password: </label>
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </p>

        <!-- Button to hash the password -->
        <p>
            <asp:Button ID="btnHashPassword" runat="server" Text="Hash Password" OnClick="btnHashPassword_Click" />
        </p>

        <!-- Label to display the hashed password -->
        <p>
            <asp:Label ID="lblHashedPassword" runat="server" Text="" ForeColor="Green"></asp:Label>
        </p>
    </form>
</body>
</html>
