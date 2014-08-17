<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Login.ascx.vb" Inherits="CodeLogically.Login" %>

<%@ Register Src="~/Controls/PopUp/Register.ascx" TagPrefix="uctrl" TagName="Reg" %>

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
        font-size:small" CssClass="smallBox" TextMode="Password"></asp:TextBox>
    <br />

    <asp:Label ID="lblRegister" runat="server" Text="Don't have a login?  "></asp:Label>
    
    <asp:LinkButton ID="lbRegister" runat="server" Text="Register Now!"></asp:LinkButton>
       
    <div id="divBottomLeft" class="bottomPopupLeft">        
        <button type="button" id="btnCancel" runat="server" onclick="__doPostBack('btnCancel','Cancel');">Cancel</button>
    </div>
    <div id="divBottomRight" class="bottomPopupRight">
        <button type="button" id="btnFinish" runat="server" onclick="__doPostBack('btnFinish','Finish');">Finish</button>
    </div>

    
      <span id="Message"
            runat="server"/>

</div>

    
<div class="none border" id="divRegisterControl" title="Help">
    <uctrl:Reg ID="Register" runat="server" />
</div>
