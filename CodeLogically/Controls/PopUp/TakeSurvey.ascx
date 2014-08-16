﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="TakeSurvey.ascx.vb" Inherits="CodeLogically.TakeSurveyControl" %>

<%@ Register Src="~/Controls/PopUp/CreateNewQuestion.ascx" TagPrefix="uctrl" TagName="CreateQuestion" %>
<%@ Register Src="~/Controls/Questions/YesNoIDK.ascx" TagPrefix="uctrl" TagName="YesNoIDK" %>
<%@ Register Src="~/Controls/Questions/TextInput.ascx" TagPrefix="uctrl" TagName="TextInput" %>
<%@ Register Src="~/Controls/Questions/MultipleChoice.ascx" TagPrefix="uctrl" TagName="MultipleChoice" %>
<%@ Register Src="~/Controls/Questions/AgreeDisagree.ascx" TagPrefix="uctrl" TagName="AgreeDisagree" %>


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