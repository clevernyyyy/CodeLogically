<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Help_QuestionTypeDef.ascx.vb" Inherits="CodeLogically.Help_QuestionTypeDef" %>



    <asp:Label ID="lblTitle" runat="server" CssClass="questionText" 
        Text="Please enter a descriptive title for your Survey!"></asp:Label>
    <br />
    <asp:TextBox ID="txtTitle" runat="server" Width="500px" style="text-align:center; font-size:small" CssClass="smallBox"></asp:TextBox>

    <asp:Button runat="server" ID="btnAddAnother"  CssClass="questionButton" Text="Add Another Question" />
    <asp:UpdatePanel runat="server" ID="upQuestions">
        <ContentTemplate>
            <asp:Repeater runat="server" ID="rptCurrentQuestions">
                <HeaderTemplate>
                    <div>
                        <th>
                            <td>
                                <asp:Label ID="lblNumber" runat="server" Text="#" />
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
