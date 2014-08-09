<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="CreateQuestions.aspx.vb" Inherits="CodeLogically.CreateQuestions" %>
<%@ Register Src="~/Controls/CreateNewQuestion.ascx" TagPrefix="uctrl" TagName="CreateQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<form runat="server">
<uctrl:CreateQuestion runat="server">
</uctrl:CreateQuestion>
</form>
</asp:Content>
