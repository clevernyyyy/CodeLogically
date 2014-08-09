<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CreateYesNo.ascx.vb" Inherits="CodeLogically.CreateYesNo" %>

<h3><asp:Label runat="server" ID="lblQuestionText" Text="Please type your question." ></asp:Label></h3>
<asp:TextBox runat="server" ID="txtQuestionText" Width="600px"></asp:TextBox>
<asp:CheckBox runat="server" ID="chkDunnoBox" Text="Check to allow 'I don't know' result"></asp:CheckBox>

