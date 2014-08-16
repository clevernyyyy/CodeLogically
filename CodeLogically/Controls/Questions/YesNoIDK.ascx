<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="YesNoIDK.ascx.vb" Inherits="CodeLogically.YesNoIDK" %>

<asp:Label runat="server" ID="lblQuestionText" CssClass="questionText"/>
<br />
<div id="rButtons" class="questionText" style="font-weight:normal; float:left;">
    <asp:RadioButton runat="server" ID="rbtYes" Text="Yes" GroupName="YNI"  Font-Size="Small"/>
    <asp:RadioButton runat="server" ID="rbtNo" Text="No" GroupName="YNI" Font-Size="Small"/>
    <asp:RadioButton runat="server" ID="rbtIDKMyBFFJill" Text="I Don't Know" GroupName="YNI" Font-Size="Small"/>
</div>
<br />