<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title Chat Logically Application</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
    <link href="~/Content/chat.css" rel="stylesheet" />
    <link href="~/Styles/jquery-ui-redmond/jquery-ui-1.10.4.custom.css" rel="stylesheet" />
    @RenderSection("scripts")
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                    @Html.ActionLink("Chat Logically", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
                    @*@Html.ActionLink("Code Logically", "Default", "Home", New With {.area = ""}, New With {.class = "navbar-brand right"})*@
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                </ul>
            </div>
        </div>
    </div>

    <div class="container body-content">
        <br />
        <br />
        @RenderBody()
        <br />
        <br />
        <br />
        <br />
        <footer style="margin-top:450px;">
            <hr />
            <p style="float:right">&copy; @DateTime.Now.Year - ChatLogically</p>
        </footer>
    </div>

    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</body>
</html>
