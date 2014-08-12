<%@ Page Title="" Language="vb" AutoEventWireup="false" 
MasterPageFile="~/Site.Master" CodeBehind="CreateQuestions.aspx.vb" 
Inherits="CodeLogically.CreateQuestions" %>

<%@ Register Src="~/Controls/PopUp/CreateSurvey.ascx" TagPrefix="uctrl" TagName="CreateSurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <uctrl:CreateSurvey runat="server" id="uctrlCreateSurvey" />
</asp:Content>
