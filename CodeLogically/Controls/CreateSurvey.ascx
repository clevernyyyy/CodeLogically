<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CreateSurvey.ascx.vb"
    Inherits="CodeLogically.CreateNewSurvey" %>

<%@ Register Src="~/Controls/CreateNewQuestion.ascx" TagPrefix="uctrl" TagName="CreateQuestion" %>
<%@ Register Src="~/Controls/YesNoIDK.ascx" TagPrefix="uctrl" TagName="YesNoIDK" %>
<%@ Register Src="~/Controls/TextInput.ascx" TagPrefix="uctrl" TagName="TextInput" %>

    <asp:Label ID="lblTitle" runat="server" Text="Please enter a descriptive title for your Survey!"></asp:Label>
    <br />
    <asp:TextBox ID="txtTitle" runat="server" Width="600px"></asp:TextBox>
    <uctrl:CreateQuestion runat="server" ID="uctrlCreateQuestion" />
    <asp:Button runat="server" ID="btnAddAnother" Text="Add Another Question" />
    <asp:UpdatePanel runat="server" ID="upQuestions">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rptCurrentQuestions">
                <HeaderTemplate>
                    <div>
                        <th>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="#" />
                            </td>
                        </th>
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div>
                        <tr>
                            <td>
                                <asp:Label runat="server" ID="lblQuestionNumber" />
                            </td>
                        </tr>
                    </div>
                                
                                    <uctrl:YesNoIDK runat="server" ID="ctrlYesNoIDK" visible="false"/>
                                    <uctrl:TextInput runat="server" ID="ctrlText" visible="false"/>
                                
                </ItemTemplate>
            </asp:Repeater>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="divBottomLeft" class="bottomPopupLeft">
        <asp:Button runat="server" ID="btnCancel" Text="Cancel Survey" />
    </div>
    <div id="divBottomRight" class="bottomPopupRight">
        <asp:Button runat="server" ID="btnFinish" Text="Finish Survey" />
    </div>
