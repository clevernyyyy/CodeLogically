
Public MustInherit Class QuestionControl
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public MustOverride Function SaveAnswer() As Boolean
    Public Overridable Property QuestionType As Enums.enmQuestionType
    Public MustOverride Sub LoadQuestion(Q As Question)

End Class