Public Class Surveys
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack() Then
            If Not CheckLogin() Then
                OpenLoginDialog()
            Else
                LoadUserLvlDisplay()    'Access Control
            End If
        End If


    End Sub




    Private Sub LoadUserLvlDisplay()
        'Only show the user things they have access for

    End Sub


    Private Function CheckLogin() As Boolean
        'Only for testing, I imagine this will be in a class/module eventually



        Return False
    End Function

    Private Sub OpenLoginDialog()
        Dim strJava As String = "OpenLoginDialog();"

        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenLoginDialog", strJava, True)

    End Sub



End Class