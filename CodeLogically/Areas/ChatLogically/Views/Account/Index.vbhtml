@Layout = Nothing

@Code   
    Dim Request = HttpContext.Current.Request
    Dim appUrl = HttpRuntime.AppDomainAppVirtualPath
    Dim baseUrl = String.Format("{0}://{1}{2}", Request.Url.Scheme, Request.Url.Authority, appUrl)
End Code

<script src="~/Scripts/Account.js"></script>
<div id="AccountForm">
    @If Not Request.IsAuthenticated Then
       @<table>
            <tr>

                <td><input class="text-box single-line" id="Id" name="Id" maxlength="10" type="text" value=""></td>
                <td>
                    <input class="button" type="button" value="Login" onclick="CallServerLogin('@baseUrl');" />
                </td>
            </tr>
        </table>
    Else
        @<span><em> Welcome, <b>@User.Identity.Name! </b> </em>
       <input class="button" type="button" style="margin-left:20px;" onclick="javascript:CallServerSignOut('@baseUrl');" value="Logout" />
            </span>
    End If
</div>
