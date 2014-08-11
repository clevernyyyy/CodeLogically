<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="AgreeDisagree.ascx.vb" Inherits="CodeLogically.AgreeDisagree" %>

<asp:Repeater id="rptOptions" runat="server">
    <HeaderTemplate>
        <table>
            <thead>
                <tr>
                    <td />
                    <td>Strongly Disagree</td>
                    <td>Somewhat Disagree</td>
                    <td>Neutral</td>
                    <td>Somewhat Agree</td>
                    <td>Strongly Agree</td>
                </tr>
            </thead>
            <ul>
    </HeaderTemplate>
    <ItemTemplate>
                    <tr>
                <li>
                        <td><asp:Label runat="server" ID="lblQuestionText" /></td>
                        <td><asp:RadioButton runat="server" ID="rbtSD" /></td>
                        <td><asp:RadioButton runat="server" ID="rbtD" /></td>
                        <td><asp:RadioButton runat="server" ID="rbtN" /></td>
                        <td><asp:RadioButton runat="server" ID="rbtA" /></td>
                        <td><asp:RadioButton runat="server" ID="rbtSA" /></td>
                </li>
                    </tr>
    </ItemTemplate>
    <FooterTemplate>
            </ul>
        </table>
    </FooterTemplate>
</asp:Repeater>


