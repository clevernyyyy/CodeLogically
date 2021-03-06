﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CreateSurvey.ascx.vb"
    Inherits="CodeLogically.CreateNewSurvey" %>

<%@ Register Src="~/Controls/Surveys/PopUp/CreateNewQuestion.ascx" TagPrefix="uctrl" TagName="CreateQuestion" %>
<%@ Register Src="~/Controls/Surveys/Questions/YesNoIDK.ascx" TagPrefix="uctrl" TagName="YesNoIDK" %>
<%@ Register Src="~/Controls/Surveys/Questions/TextInput.ascx" TagPrefix="uctrl" TagName="TextInput" %>
<%@ Register Src="~/Controls/Surveys/Questions/MultipleChoice.ascx" TagPrefix="uctrl" TagName="MultipleChoice" %>
<%@ Register Src="~/Controls/Surveys/Questions/AgreeDisagree.ascx" TagPrefix="uctrl" TagName="AgreeDisagree" %>

    <asp:Label ID="lblTitle" runat="server" CssClass="smallfont" 
        Text="Please enter a descriptive title for your Survey!"></asp:Label>
    <br />
    <asp:TextBox ID="txtTitle" runat="server" Width="500px" style="text-align:center; font-size:small" CssClass="smallBox"></asp:TextBox>
    <uctrl:CreateQuestion runat="server" ID="uctrlCreateQuestion" />
    <asp:Button runat="server" ID="btnAddAnother"  CssClass="AddQuestionButton" Text="Add Another Question" />
    <br />
    <div id="questionContent" runat="server" style="margin-top:15px; float:left; 
        width:600px; height:400px; overflow-y:auto; overflow-x:hidden; position:absolute;">
        <asp:UpdatePanel runat="server" ID="upQuestions">
            <ContentTemplate>
                <asp:Repeater runat="server" ID="rptCurrentQuestions" >
                    <ItemTemplate>
                        <div id="divQuestions" style="float:left">
                            <tr>
                                <td>
                                    <asp:Label runat="server" ID="lblQuestionNumber" CssClass="numberText" />
                                    <uctrl:YesNoIDK runat="server" ID="ctrlYesNoIDK" visible="false" />
                                    <uctrl:TextInput runat="server" ID="ctrlTextInput" visible="false"/>
                                    <uctrl:MultipleChoice runat="server" ID="ctrlMultipleChoice" visible="false"/>   
                                    <uctrl:AgreeDisagree runat="server" ID="ctrlAgreeDisagree" visible="false"/>  
                                </td>
                            </tr>
                        <hr style="width:250; border:none; position:absolute; left:0; right:0; margin-left:-200px;"/> 
                        <br />     
                        </div>       
                        <br />                
                    </ItemTemplate>    
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="divBottomLeft" class="bottomPopupLeft">
        <asp:Button runat="server" ID="btnCancel" class="bottomButtons" Text="Cancel Survey" />
    </div>
    <div id="divBottomRight" class="bottomPopupRight">
        <asp:Button runat="server" ID="btnFinish" class="bottomButtons" Text="Finish Survey" />
    </div>
