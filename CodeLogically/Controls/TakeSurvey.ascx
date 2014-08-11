<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TakeSurvey.ascx.vb" Inherits="CodeLogically.TakeSurveyControl" %>

<%@ Register Src="~/Controls/CreateNewQuestion.ascx" TagPrefix="uctrl" TagName="CreateQuestion" %>
<%@ Register Src="~/Controls/YesNoIDK.ascx" TagPrefix="uctrl" TagName="YesNoIDK" %>
<%@ Register Src="~/Controls/TextInput.ascx" TagPrefix="uctrl" TagName="TextInput" %>
<%@ Register Src="~/Controls/MultipleChoice.ascx" TagPrefix="uctrl" TagName="MultipleChoice" %>
<%@ Register Src="~/Controls/AgreeDisagree.ascx" TagPrefix="uctrl" TagName="AgreeDisagree" %>


            <asp:Repeater runat="server" ID="rptSurvey">
                <ItemTemplate>
<%--                    <div>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblQuestionNumber" />
                            </td>
                        </tr>
                    </div>--%>
                    <uctrl:YesNoIDK runat="server" ID="ctrlYesNoIDK" visible="false"/>
                    <uctrl:TextInput runat="server" ID="ctrlTextInput" visible="false"/>
                    <uctrl:MultipleChoice runat="server" ID="ctrlMultipleChoice" visible="false"/>     
                    <uctrl:AgreeDisagree runat="server" ID="ctrlAgreeDisagree" visible="false"/>                                 
                </ItemTemplate>
            </asp:Repeater>