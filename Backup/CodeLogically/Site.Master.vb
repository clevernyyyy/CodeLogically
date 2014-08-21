Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Request.Url.AbsoluteUri.Contains("Default") Then
            mnuSurveys.Visible = True
            mnuCreateSurveys.Visible = False
            mnuTakeSurveys.Visible = False
            mnuSurveyAnalytics.Visible = False
        ElseIf Request.Url.AbsoluteUri.Contains("Survey") Then
            mnuSurveys.Visible = False
            mnuCreateSurveys.Visible = True
            mnuTakeSurveys.Visible = True
            mnuSurveyAnalytics.Visible = True
        End If


    End Sub

End Class