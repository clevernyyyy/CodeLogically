@Code
    ViewBag.Title = "Index"
End Code

<script src="Scripts/jquery.signalR-1.0.1.min.js" type="text/javascript"></script>
@*  SignalR dynamically created fails*@
<script src="/signalr/hubs" type="text/javascript"></script>
<script src="~/Scripts/SignalRMethods.js"></script>
@*  On loading call the*@

<script type="text/javascript">
    RegisterNewClient();
</script>


<table id="SendMsgContext">
    <tr>
        <td style="table-layout:fixed" class="tableBorders FriendlyBackground box">
            <div id="GlobalMessages">
                @* Global Chat Messages*@
                <div class="GlobMsg" style="color:#cbcbcb"> System Version (or anything to default at top of page) </div>
            </div>
        </td>
        <td id="ActiveUserCount" rowspan="2" class="tableBorders FriendlyBackground UserList">
            @*  Active User List*@

        </td>
    </tr>
    <tr>
        <td>
            @*  Send a message*@
            <div id="SendForm">
                <table id="InputElem" class="tableBorders FriendlyBackground">
                    <tr>
                        <td>
                            @Html.TextBox("GlobalMsgText")
                        </td>
                        <td>
                            <input class="button" type="button" value="Send" onclick="SendGlobalMessage($('#GlobalMsgText'))" />
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>

<script type="text/javascript">
        $('#GlobalMsgText').keyup(function (event) {
            if (event.keyCode == 13) {
                SendGlobalMessage($('#GlobalMsgText'))
            }
        });
</script>
