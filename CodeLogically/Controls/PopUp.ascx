<%--<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PopUp.ascx.vb" Inherits="CodeLogically.PopUp" %>

<form runat="server">
<div class="popup" id="popup<%=PopupId%>">
    <a class="popupClose" onclick="javscript:disablePopups();" id="popupClose<%=PopupId%>">X</a>  
    <h1><asp:Label ID="lblPopUpTitle" runat="server"></asp:Label></h1>
    <div class="popupArea" id="popupArea<%=PopupId%>">
        <div class="popupContent">
            <asp:PlaceHolder runat="server" ID="phContent" ></asp:PlaceHolder>
        </div>
        <center>
            <asp:PlaceHolder runat="server" ID="phButton" ></asp:PlaceHolder>
        </center>
    </div>
</div>
<div class="backgroundPopup" id="backgroundPopup<%=PopupId%>"></div>
<asp:HiddenField ID="hClickOutAllowed" runat="server" Value="true" /> 
</form>
 --%>