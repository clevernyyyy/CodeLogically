<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MultipleChoice.ascx.vb" Inherits="CodeLogically.MultipleChoice" %>


<asp:Label runat="server" ID="lblQuestionText"  CssClass="questionText"/>
<asp:DropDownList ID="ddlOptions" runat="server" visible="false"  style="font-size:small" CssClass="ctrlDropBox" />
<br />
<asp:RadioButtonList ID="rblRadioButtons" runat="server" visible="false" Font-Size="Small" />