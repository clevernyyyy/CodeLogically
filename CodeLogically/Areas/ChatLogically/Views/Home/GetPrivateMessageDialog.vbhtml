﻿@Code
    Layout = Nothing
End Code

<table cellspacing="0" cellpadding="0" id="@string.Format("{0}_dialog", ViewBag.ConnectionId)" class="DialogTable tableMainBorder">
    <tr class="DialogHeader">
        <td class="UserNameAtTop">
            <b>@ViewBag.UserName</b>
        </td>
        <td>
            <input class="CloseButton button" type="button" onclick="CloseModalWindows('@ViewBag.ConnectionId')" value="X" />
        </td>
    </tr>
    <tr>
        <td colspan="2" style="background-color:#9dd7d3">
            <div id="@string.Format("{0}_msgContent",ViewBag.ConnectionId)" class="privateMessageContentBox">

            </div>
        </td>
    </tr>
    <tr>
        <td colspan="2" style="background-color:#9dd7d3">
            <input type="text" id="@string.Format("{0}_tb",ViewBag.ConnectionId)" class="PrivateMsg" name="PrivateMsg" />
            <input type="button" value="Send"
                   onclick="SendPrivateMessage($('#@string.Format("{0}_tb",ViewBag.ConnectionId)'), '@ViewBag.ConnectionId');"
                   class="button" />
        </td>
    </tr>
</table>

<script type="text/javascript">

        $(document).ready(function(){
            $('#@string.Format("{0}_tb",ViewBag.ConnectionId)').focus();
        });


        var textBox =  $('#@string.Format("{0}_tb",ViewBag.ConnectionId)')
        textBox.keyup(function (event) {
            if (event.keyCode == 13) {
                SendPrivateMessage(textBox, '@ViewBag.ConnectionId');
            }
        });
</script>

