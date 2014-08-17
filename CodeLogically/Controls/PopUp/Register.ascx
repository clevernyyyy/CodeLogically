<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Register.ascx.vb" Inherits="CodeLogically.Register" %>
<h3>
    <font face="Verdana">Registration Page</font>
</h3>
<asp:Panel ID="Panel1" runat="server" DefaultButton="cmdRegister" 
    GroupingText="Account Information" Width="510px">
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="125px">Name:</asp:Label>
        </span><span>
        <asp:TextBox ID="txtFName" runat="server" type="text" />
        </span><span>
        <asp:TextBox ID="txtMName" runat="server" type="text" width="25px" />
        </span><span>
        <asp:TextBox ID="txtLName" runat="server" type="text" />
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="125px">Email:</asp:Label>
        </span><span>
        <asp:TextBox ID="txtEmail" runat="server" AutoComplete="off" 
            AutoCompleteType="Disabled" type="text" width="300px" />
        <asp:RequiredFieldValidator ID="vUserName" runat="server" 
            ControlToValidate="txtEmail" Display="Static" ErrorMessage="Email is required" 
            Width="10px" />
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="125px">Confirm Email:</asp:Label>
        </span><span>
        <asp:TextBox ID="txtEmail2" runat="server" AutoComplete="off" 
            AutoCompleteType="Disabled" type="text" width="300px" />
        <asp:CompareValidator ID="CompareEmail" runat="server" 
            ControlToCompare="txtEmail" ControlToValidate="txtEmail2" 
            CssClass="failureNotification" Display="Dynamic" 
            ErrorMessage="The Confirm Email must match the Email entry." 
            ValidationGroup="EmailValidationGroup" Width="10px">*</asp:CompareValidator>
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="125px">Password:</asp:Label>
        </span><span>
        <asp:TextBox ID="txtUserPass" runat="server" AutoComplete="off" 
            AutoCompleteType="Disabled" type="password" width="300px" />
        <asp:RequiredFieldValidator ID="vUserPass" runat="server" 
            ControlToValidate="txtUserPass" Display="Static" 
            ErrorMessage="Password is required" Width="10px" />
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="125px">Confirm Password:</asp:Label>
        </span><span>
        <asp:TextBox ID="txtUserPass2" runat="server" AutoComplete="off" 
            AutoCompleteType="Disabled" type="password" width="300px" />
        <asp:CompareValidator ID="ComparePassword" runat="server" 
            ControlToCompare="txtUserPass" ControlToValidate="txtUserPass2" 
            CssClass="failureNotification" Display="Dynamic" 
            ErrorMessage="The Confirm Password must match the Password entry." 
            ValidationGroup="PasswordValidationGroup" Width="10px">*</asp:CompareValidator>
        </span>
    </div>
</asp:Panel>
<asp:Button ID="cmdRegister" runat="server" Text="Register" type="submit" />
<p>
    <asp:Label ID="lblMsg" runat="server" Font-Name="Verdana" Font-Size="10" 
        ForeColor="red" />
</p>

