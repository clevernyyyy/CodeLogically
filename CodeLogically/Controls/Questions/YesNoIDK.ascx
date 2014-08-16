<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="YesNoIDK.ascx.vb" Inherits="CodeLogically.YesNoIDK" %>

<asp:Label runat="server" ID="lblQuestionText" CssClass="questionText"/>
<br />
<div id="rButtons" class="questionText" style="font-weight:normal; float:left;">
    <label class="radio-inline">
        <input type="radio" runat="server" name="YNI" id="rbtYes" value="Yes" />Yes
    </label>
    <label class="radio-inline">
        <input type="radio" runat="server" name="YNI" id="rbtNo" value="No" />No  
    </label>  
    <label class="radio-inline">
        <input type="radio" runat="server" name="YNI" id="rbtIDKMyBFFJill" value="IDK" />I Don't Know
    </label>


<%--
    Replaced the following with the bootstrap HTML Input Radio Buttons.  They look and format nicer.  
    Keeping these here in case the new ones cause errors in the code behind at all.--%>

<%--    <asp:RadioButton runat="server" ID="rbtYes" Text="Yes" GroupName="YNI"  Font-Size="Small"/>
    <asp:RadioButton runat="server" ID="rbtNo" Text="No" GroupName="YNI" Font-Size="Small"/>
    <asp:RadioButton runat="server" ID="rbtIDKMyBFFJill" Text="I Don't Know" GroupName="YNI" Font-Size="Small"/>--%>
</div>
<br />