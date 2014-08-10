<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CreateNewQuestion.ascx.vb" Inherits="CodeLogically.CreateNewQuestion" %>

<%@ Register Src="~/Controls/UserOption.ascx" TagPrefix="uctrl" TagName="UserOption" %>

<h3><asp:Label runat="server" ID="lblQuestionText" Text="Please type your question." ></asp:Label></h3>
<asp:TextBox runat="server" ID="txtQuestionText" Width="600px"></asp:TextBox>
<asp:DropDownList runat="server" ID="ddlQuestionType" Width="100px" AutoPostBack="true"></asp:DropDownList>

<asp:ScriptManager runat="server"></asp:ScriptManager>
<asp:UpdatePanel runat="server">
    <ContentTemplate>
        <asp:CheckBox runat="server" ID="chkIDKMyBFFJill" Text="Check to allow 'I don't know' result"></asp:CheckBox>
        <asp:CheckBox runat="server" ID="chkMultiLine" Text="Check to allow Multi-Line entry"></asp:CheckBox>
        <asp:Button runat="server" ID="btnAddOption" Text="Add Option" Width="100px" ></asp:Button>
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
        <asp:Panel ID="RadioButtonsPanel" runat="server" AutoPostBack ="false"/>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAddOption" />
        <asp:AsyncPostBackTrigger ControlID="ddlQuestionType" />
    </Triggers>
</asp:UpdatePanel>

