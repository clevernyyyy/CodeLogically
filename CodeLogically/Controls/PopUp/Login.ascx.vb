Public Class Login
    Inherits System.Web.UI.UserControl
    Public ReadOnly Property Username As String
        Get
            Return txtUserName.Text
        End Get
    End Property
    Public ReadOnly Property Password As String
        Get
            'Return txtPassword.Text
            Return inputPassword.Value
        End Get
    End Property
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            'If (Convert.ToString(Request.Form("__EVENTARGUMENT")) = "Cancel") Then
            '    'Close
            'ElseIf (Convert.ToString(Request.Form("__EVENTARGUMENT")) = "Finish") Then
            '    'SignIn()
            'End If
        End If

        AddRegJS(lbRegister)
    End Sub
    Private Sub SignIn()
        SignIn(txtUserName.Text, txtPassword.Text)
    End Sub
    Public Sub SignIn(userName As String, passWord As String)
        Dim objUser As User
        If ValidateUser(userName, passWord, objUser) Then
            Session("User") = objUser
        End If
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