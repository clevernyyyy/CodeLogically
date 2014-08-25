﻿<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Register.ascx.vb" Inherits="CodeLogically.Register" %>

 <!-- Custom styles for this control -->
 <link href="/Styles/Login/Login.css" rel="stylesheet" />

<h3>
    <font face="Verdana" color="White">Registration Page</font>
</h3>
<asp:Panel ID="Panel1" runat="server" DefaultButton="cmdRegister" 
    GroupingText="Account Information" ForeColor="White" Width="750px">
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="150px">Name:</asp:Label>
        </span><span>
        <input type="text" id="inputFName" placeholder="First Name" runat="server" />
        <%--<asp:TextBox ID="txtFName" runat="server" type="text" />--%>
        <input type="text" id="inputMName" placeholder="MI" runat="server" maxlength="2" size="2" />
        <%--<asp:TextBox ID="txtMName" runat="server" type="text" width="25px" />--%>
        <input type="text" id="inputLName" placeholder="Last Name" runat="server" />
        <%--<asp:TextBox ID="txtLName" runat="server" type="text" />--%>
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="150px">NickName:</asp:Label>
        </span><span>
        <input type="text" id="inputNickName" placeholder="NickName" runat="server" />
        <%--<asp:TextBox ID="txtNickName" runat="server" type="text" />--%>
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="150px">Email:</asp:Label>
        </span><span>
        <input type="text" id="inputEmail" placeholder="Email" runat="server" />
<%--        <asp:TextBox ID="txtEmail" runat="server" AutoComplete="off" 
            AutoCompleteType="Disabled" type="text" width="300px" />--%>
        <asp:RequiredFieldValidator ID="vUserName" runat="server" 
            ControlToValidate="inputEmail" Display="Static" ErrorMessage="Email is required" 
            Width="200px" />
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="150px">Confirm Email:</asp:Label>
        </span><span>
        <input type="text" id="inputEmail2" placeholder="Confirm Email" runat="server" />
<%--        <asp:TextBox ID="txtEmail2" runat="server" AutoComplete="off" 
            AutoCompleteType="Disabled" type="text" width="300px" />--%>
        <asp:CompareValidator ID="CompareEmail" runat="server" 
            ControlToCompare="inputEmail" ControlToValidate="inputEmail2" 
            CssClass="failureNotification" Display="Dynamic" 
            ErrorMessage="The Confirm Email must match the Email entry." 
            ValidationGroup="EmailValidationGroup" Width="200px">*</asp:CompareValidator>
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="150px">Password:</asp:Label>
        </span><span>
        <input type="text" id="inputUserPass" placeholder="Password" runat="server" />
 <%--       <asp:TextBox ID="txtUserPass" runat="server" AutoComplete="off" 
            AutoCompleteType="Disabled" type="password" width="300px" />--%>
        <asp:RequiredFieldValidator ID="vUserPass" runat="server" 
            ControlToValidate="inputUserPass" Display="Static" 
            ErrorMessage="Password is required" Width="200px" />
        </span>
    </div>
    <div>
        <span style="text-align:right;">
        <asp:Label runat="server" Width="150px">Confirm Password:</asp:Label>
        </span><span>
        <input type="text" id="inputUserPass2" placeholder="Confirm Password" runat="server" />
<%--        <asp:TextBox ID="txtUserPass2" runat="server" AutoComplete="off" 
            AutoCompleteType="Disabled" type="password" width="300px" />--%>
        <asp:CompareValidator ID="ComparePassword" runat="server" 
            ControlToCompare="inputUserPass" ControlToValidate="inputUserPass2" 
            CssClass="failureNotification" Display="Dynamic" 
            ErrorMessage="The Confirm Password must match the Password entry." 
            ValidationGroup="PasswordValidationGroup" Width="200px">*</asp:CompareValidator>
        </span>
    </div>
</asp:Panel>
<div id="divBtn" style="float:right">
    <asp:Button ID="cmdRegister" runat="server" Text="Register" type="submit" />
</div>
<p>
    <asp:Label ID="lblMsg" runat="server" Font-Name="Verdana" Font-Size="10" 
        ForeColor="red" />
</p>

