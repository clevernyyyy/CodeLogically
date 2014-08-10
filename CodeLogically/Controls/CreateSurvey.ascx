﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="CreateSurvey.ascx.vb"
    Inherits="CodeLogically.CreateNewSurvey" %>

<%@ Register Src="~/Controls/CreateNewQuestion.ascx" TagPrefix="uctrl" TagName="CreateQuestion" %>

    <asp:Label ID="lblTitle" runat="server" Text="Please enter a descriptive title for your Survey!"></asp:Label>
    <br />
    <asp:TextBox ID="txtTitle" runat="server" Width="600px"></asp:TextBox>
    <uctrl:CreateQuestion runat="server" ID="uctrlCreateQuestion" />
    <asp:Button runat="server" ID="btnAddAnother" Text="Add Another Question" />
    <asp:Repeater runat="server" ID="rptCurrentQuestions">
        <HeaderTemplate>
            <div>
                <th>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="#" />
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Text" />
                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Type" />
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
                    <td>
                        <asp:Label runat="server" ID="lblQuestionText" />
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblQuestionType" />
                    </td>
                </tr>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div id="divBottomLeft" class="bottomPopupLeft">
        <asp:Button runat="server" ID="btnCancel" Text="Cancel Survey" />
    </div>
    <div id="divBottomRight" class="bottomPopupRight">
        <asp:Button runat="server" ID="btnFinish" Text="Finish Survey" />
    </div>
