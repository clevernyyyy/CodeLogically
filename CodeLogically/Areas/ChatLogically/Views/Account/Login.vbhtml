@Model ConnectionMappingSample.Models.LoginModel

@ViewBag.Title = "Login";


<h2>Login</h2>

 @Using (Html.BeginForm())


    @Html.EditorForModel()
    @<input type="submit" class="btn" value="Login" />

 End Using