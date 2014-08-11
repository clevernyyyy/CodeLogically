
Public MustInherit Class CreateQuestion
    Inherits System.Web.UI.UserControl

    Public ParentSurvey As Survey


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public MustOverride Function SaveQuestion() As Boolean
End Class
