<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CreateNewQuestion.ascx.vb" Inherits="CodeLogically.CreateNewQuestion" %>

<%@ Register Src="~/Controls/PopUp/UserOption.ascx" TagPrefix="uctrl" TagName="UserOption" %>

 <!-- Custom styles for this control -->
 <link href="/Styles/PerControl/CreateControl.css" rel="stylesheet" />

 <!-- Scripts -->
 <script type="text/javascript" src="/Scripts/PerPage/CreateSurvey.js?cachebreak=08092014"></script>

<br />
<asp:Label runat="server" ID="lblQuestionType" CssClass="questionText" Text="Question Type?" ></asp:Label>
<asp:Label runat="server" ID="lblQuestionText" CssClass="questionText questionType" Text="Please type your question." ></asp:Label>
<br />
<div id="divQuestionTypeDefinitions" runat="server">
    <a id="QuestionTypeDefinitions" runat="server" href="" >
        <img class="img img-circle" style="float:left;" src="/img/help.ico" height="25px" width="25px" alt="">
    </a>
</div>
<asp:DropDownList runat="server" ID="ddlQuestionType" Width="100px" style="font-size:small" 
CssClass="smallBox" AutoPostBack="true"></asp:DropDownList>
<asp:TextBox runat="server" ID="txtQuestionText" Width="400px" style="font-size:small" CssClass="smallBox"></asp:TextBox>

<asp:ScriptManager runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:CheckBox runat="server" ID="chkIDKMyBFFJill" CssClass="questionText" Text="Check to allow 'I don't know' result"></asp:CheckBox>
        <asp:CheckBox runat="server" ID="chkMultiLine" CssClass="questionText" Text="Check to allow Multi-Line entry"></asp:CheckBox>
        <asp:Button runat="server" ID="btnAddOption" CssClass="questionButton" Text="Add Option" Width="100px" ></asp:Button>
        <asp:TextBox ID="txtRadioAmount" runat="server" AutoPostBack="true" ></asp:TextBox>
        <div runat="server" id="divOptions">
            <asp:Repeater runat="server" ID="rptUserOptions">
                <ItemTemplate>
                    <div>
                        <uctrl:UserOption id="ctrlUO" runat="server"></uctrl:UserOption>
                    </div>
                </ItemTemplate>
            </asp:Repeater>        
        </div>
        <asp:Panel ID="pnlRadioButtons" runat="server" AutoPostBack ="false"/>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAddOption" />
        <asp:AsyncPostBackTrigger ControlID="ddlQuestionType" />
    </Triggers>
</asp:UpdatePanel>

