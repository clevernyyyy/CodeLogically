<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="YesNoIDK.ascx.vb" Inherits="CodeLogically.YesNoIDK" %>

<h3><asp:Label runat="server" ID="lblQuestionText" /></h3>
&gt;&gt;
<asp:RadioButton runat="server" ID="rbtYes" Text="Yes" GroupName="YNI" />
<asp:RadioButton runat="server" ID="rbtNo" Text="No" GroupName="YNI" />
<asp:RadioButton runat="server" ID="rbtIDKMyBFFJill" Text="I Don't Know" GroupName="YNI" />