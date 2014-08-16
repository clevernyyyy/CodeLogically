<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Login.ascx.vb" Inherits="CodeLogically.Login1" %>


<%--Random test HTML--%>

    <asp:Label ID="lblLogin" runat="server" CssClass="questionText" 
        Text="Please Login!"></asp:Label>
    <br />
    <asp:Label Text="User Name:">User Name:</asp:Label>
    <asp:TextBox ID="txtLogin" runat="server" Width="200px" style="text-align:left; 
        font-size:small" CssClass="smallBox"></asp:TextBox>
        <br />
    <asp:Label Text="Password:">Password:</asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Width="200px" style="text-align:left; 
        font-size:small" CssClass="smallBox"></asp:TextBox>
   
    <div id="divBottomLeft" class="bottomPopupLeft">
        <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
    </div>
    <div id="divBottomRight" class="bottomPopupRight">
        <asp:Button runat="server" ID="btnFinish" Text="Login" />
    </div>
