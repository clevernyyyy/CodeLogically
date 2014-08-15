<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="YesNoIDK.ascx.vb" Inherits="CodeLogically.YesNoIDK" %>

<asp:Label runat="server" ID="lblQuestionText" CssClass="questionText"/>
<br />
<div id="rButtons" class="questionText">
    &gt;&gt;
    <asp:RadioButton runat="server" ID="rbtYes" Text="Yes" GroupName="YNI" CssClass="questionText"/>
    <asp:RadioButton runat="server" ID="rbtNo" Text="No" GroupName="YNI" CssClass="questionText" />
    <asp:RadioButton runat="server" ID="rbtIDKMyBFFJill" Text="I Don't Know" GroupName="YNI"  CssClass="questionText"/>
</div>