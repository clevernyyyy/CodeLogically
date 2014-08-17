Public Class Login
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        AddRegJS(lbRegister)
    End Sub
    Private Sub SignIn()
        SignIn(txtUserName.Text, txtPassword.Text)
    End Sub
    Private Sub SignIn(userName As String, passWord As String)
        Dim objUser As User
        If ValidateUser(userName, passWord, objUser) Then
            Session("User") = objUser
        End If
    End Sub

    Private Sub btnFinish_Click(sender As Object, e As System.EventArgs) Handles btnFinish.Click
        SignIn()
    End Sub

#Region "JavaScript"
    Private Sub AddRegJS(ByVal lb As LinkButton)
        Dim strJava As String = ""

        'Make the AJAX call
        strJava = "javascript:OpenRegister();"
        lb.Attributes.Add("onclick", strJava)

    End Sub
#End Region

End Class