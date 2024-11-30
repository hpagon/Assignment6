<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Captcha.ascx.cs" Inherits="ShopWebApp.Captcha" %>
<div class="captcha-container" style="border: 1px solid black; width: fit-content">
    <div ID="promptContainer" runat="server">
        <p>Type the following string.</p>
        <asp:Image ID="captchaImage" runat="server" />
        <br />
        <asp:TextBox ID="captchaStringInput" runat="server"></asp:TextBox>
        <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submit_Click" />
    </div>
    <div ID="resultContainer" runat="server">
        <asp:Label ID="result" runat="server" Text=" "></asp:Label>
    </div>
</div>