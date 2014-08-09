Public Class CreateYesNo
    Inherits CreateQuestion

    Public Sub New(S As Survey)
        ParentSurvey = S
    End Sub
    Public Sub New()
    End Sub
    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Overrides Function SaveQuestion() As Boolean
        Dim Q As New Question(txtQuestionText.Text, IIf(chkDunnoBox.Checked, Enums.enmQuestionType.YesNoIDK, Enums.enmQuestionType.YesNo))
        ParentSurvey.AddQuestion(Q)
        Return True
    End Function
End Class