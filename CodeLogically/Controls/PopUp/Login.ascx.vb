Public Class Login
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

    Private Sub btnReg_Click(sender As Object, e As System.EventArgs) Handles btnReg.Click
        OpenRegisterControl()
    End Sub


    Private Sub lbRegister_ServerClick(sender As Object, e As System.EventArgs) Handles lbRegister.ServerClick
        OpenRegisterControl()
    End Sub

    Private Sub OpenRegisterControl()
        Dim strJava As String = "OpenRegister();"

        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenRegister", strJava, True)

    End Sub

End Class