﻿<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width" />
    <title>@*@ViewBag.Title*@</title>

    <link href="~/Content/Site.css" rel="stylesheet" />
    <script src="http://code.jquery.com/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js" type="text/javascript"></script>
    <script src="~/Scripts/Helpers.js"></script>
    <link href="~/Content/DialogStyle.css" rel="stylesheet" />


</head>
<body>

    <table id="ContentTable" class="tableMainBorder FriendlyBackground">
        @* Header*@
        <tr>
            <td>
                Chat Logically
                @*<img src="~/Content/Image/asp-net-signalr-chat-place.png" />*@
            </td>
            <td id="login" style="text-align: right;">
                @*@Html.Action("Index", "Account")*@
            </td>
        </tr>
        <tr>
            <td colspan="2" class="tableBorders">
                <a href="http://codelogically.com">Code Logically</a>
            </td>
        </tr>
        @* Body*@
        <tr>
            <td colspan="2">
                @RenderBody()
            </td>
        </tr>
        @* Footer*@
        <tr class="footer">
            <td colspan="2"></td>
        </tr>


    </table>


    <div id="DialogContent">
    </div>


    @RenderSection("scripts", False)
    <script src="~/Scripts/DialogWindows.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dialogTable = $('.DialogTable');
            if (dialogTable.length > 0) {
                dialogTable.draggable();
            }
        });

    </script>
</body>
</html>