<%@ Page Title="" Language="vb" AutoEventWireup="false" 
MasterPageFile="~/Site.Master" CodeBehind="CreateQuestions.aspx.vb" 
Inherits="CodeLogically.CreateQuestions" %>

<%@ Register Src="~/Controls/CreateNewQuestion.ascx" TagPrefix="uctrl" TagName="CreateQuestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <uctrl:CreateQuestion runat="server" id="uctrlCreateQuestion" />
    <asp:Button runat="server" ID="btnAddAnother" Text="Add Another Question" />
<asp:Repeater runat="server" ID="rptCurrentQuestions">
    <HeaderTemplate>
        <div>
            <th>
                <td><asp:Label runat="server" Text="#" /></td>
                <td><asp:Label runat="server" Text="Text" /></td>
                <td><asp:Label runat="server" Text="Type" /></td>
            </th>
        </div>
    </HeaderTemplate>
    <ItemTemplate>
        <div>
            <tr>
                <td><asp:Label runat="server" ID="lblQuestionNumber" /></td>
                <td><asp:Label runat="server" ID="lblQuestionText" /></td>
                <td><asp:Label runat="server" ID="lblQuestionType" /></td>
            </tr>
        </div>
    </ItemTemplate>
</asp:Repeater>

</asp:Content>
