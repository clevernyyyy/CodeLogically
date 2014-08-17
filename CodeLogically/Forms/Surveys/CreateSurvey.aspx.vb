
Public Class CreateSurvey
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If HttpContext.Current.Session("User") IsNot Nothing Then
            divLoginOpen.Visible = False
        End If
    End Sub

    Private Sub btnDyanmicSurvey_Click(sender As Object, e As System.EventArgs) Handles btnDynamicSurvey.ServerClick
        Dim objSurvey As New Survey(0, 0, "", 1, Date.Now())
        Session("Survey") = objSurvey

        OpenSurveyEditor()

        'SimplePopup(Me, "Please fill out questions.", "Input Required")

    End Sub

    Private Sub OpenSurveyEditor()
        Dim strJava As String = "OpenSurveyEditor();"

        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenSurveyEditor", strJava, True)

    End Sub

End Class