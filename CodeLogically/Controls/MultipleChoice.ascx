<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="MultipleChoice.ascx.vb" Inherits="CodeLogically.MultipleChoice" %>

<h3><asp:Label runat="server" ID="lblQuestionText" /></h3>
<br />&gt;&gt;

<body>
    <form id="radioForm" runat="server">
        <asp:Panel ID="pnlRadioButtons" runat="server" visible="false"/>
        <asp:DropDownList ID="ddlOptions" runat="server" visible="false"/>
    </form>
</body>