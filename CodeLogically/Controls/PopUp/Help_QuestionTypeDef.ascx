<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Help_QuestionTypeDef.ascx.vb" Inherits="CodeLogically.Help_QuestionTypeDef" %>



<div id="divQuestionTypes" runat="server">
    <div id="divYesNo" runat="server">
        <asp:Label ID="lblYesNo" runat="server" Text="Yes/No Question Type:" CssClass="questionTypeFont"></asp:Label>
        <br />
        <asp:Label ID="lblExample1" runat="server" Text="#1.)  Example Question?" CssClass="smallfont"></asp:Label>
        <br />
        <div id="rButtons" class="questionText" style="font-weight:normal; float:left;">
            <label class="radio-inline">
                <input type="radio" runat="server" name="YNI" id="rbtYes" value="Yes" />Yes
            </label>
            <label class="radio-inline">
                <input type="radio" runat="server" name="YNI" id="rbtNo" value="No" />No  
            </label>  
            <label class="radio-inline">
                <input type="radio" runat="server" name="YNI" id="rbtIDKMyBFFJill" value="IDK" />I Don't Know (Optional)
            </label>
        </div>
        <br />
    </div>
    <div id="divTextInput" runat="server">
        <br />
        <asp:Label ID="lblTextInput" runat="server" Text="Text Input Type:" CssClass="questionTypeFont"></asp:Label>
        <br />
        <asp:Label ID="lblExample2" runat="server" Text="#2.)  Example Question?" CssClass="smallfont"></asp:Label>
        <br />
        <asp:TextBox runat="server" ID="txtQuestionAnswer" Width="150px" style="text-align:left; font-size:small" CssClass="smallBox"/>
        <asp:Label ID="lblMultiLine" runat="server" Text="(Multi-line Optional)" CssClass="smallfont"></asp:Label>
    </div>
    <div id="divMultipleChoice" runat="server">
        <br />
        <asp:Label ID="lblDropDown" runat="server" Text="DropDown Type:" CssClass="questionTypeFont"></asp:Label>
        <br />
        <asp:Label ID="lblExample3" runat="server" Text="#3.)  Example Question?" CssClass="smallfont"></asp:Label>
        <asp:DropDownList ID="ddlOptions" runat="server" style="font-size:small" Width="100px" CssClass="ctrlDropBox" />
        <br />
        <br />
        <asp:Label ID="lblMultiRadio" runat="server" Text="Multi Radio Type:" CssClass="questionTypeFont"></asp:Label>
        <br />
        <asp:Label ID="lblExample4" runat="server" Text="#4.)  Example Question?:" CssClass="smallfont"></asp:Label>



    </div>
    <div id="divAgreeDisagree" runat="server">
    
    </div>
</div>