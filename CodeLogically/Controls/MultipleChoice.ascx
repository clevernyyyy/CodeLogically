<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MultipleChoice.ascx.vb" Inherits="CodeLogically.MultipleChoice" %>

<h3><asp:Label runat="server" ID="lblQuestionText" /></h3>
    <asp:RadioButtonList ID="rblRadioButtons" runat="server" visible="false"/>
    <asp:DropDownList ID="ddlOptions" runat="server" visible="false"/>
