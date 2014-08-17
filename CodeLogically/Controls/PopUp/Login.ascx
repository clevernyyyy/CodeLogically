<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Login.ascx.vb" Inherits="CodeLogically.Login" %>


<%--Random test HTML--%>
<div id="divLoginControl" >
    <asp:Label ID="lblLogin" runat="server" CssClass="questionText" 
        Text="Please Login!"></asp:Label>
    <br />
    <asp:Label id="lblUser" runat="server" Text="User Name:">User Name:</asp:Label>
    <asp:TextBox ID="txtUserName" runat="server" Width="200px" style="text-align:left; 
        font-size:small" CssClass="smallBox"></asp:TextBox>
        <br />
    <asp:Label id="lblPassword" runat="server" Text="Password:">Password:</asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" Width="200px" style="text-align:left; 
        font-size:small" CssClass="smallBox"></asp:TextBox>
   
    <div id="divBottomLeft" class="bottomPopupLeft">
        <asp:Button runat="server" ID="btnCancel" Text="Cancel" />
    </div>
    <div id="divBottomRight" class="bottomPopupRight">
        <asp:Button runat="server" ID="btnFinish" Text="Login" />
    </div>

</div>
