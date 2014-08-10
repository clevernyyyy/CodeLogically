Public Class CreateNewSurvey
    Inherits System.Web.UI.UserControl

    Private objSurvey As Survey
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Survey") Is Nothing Then
                objSurvey = New Survey(1, 0)
                Session("Survey") = objSurvey
            Else
                objSurvey = Session("Survey")
            End If
            NewQuestion()
        Else
            objSurvey = Session("Survey")
        End If
    End Sub
    Private Sub LoadSurvey()
        Dim collQuestions As Questions = objSurvey.Questions
        rptCurrentQuestions.DataSource = collQuestions
        rptCurrentQuestions.DataBind()
    End Sub

    Private Sub rptCurrentQuestions_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptCurrentQuestions.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Q As Question = e.Item.DataItem
            Dim lblNum As Label = e.Item.FindControl("lblQuestionNumber")
            Dim lblText As Label = e.Item.FindControl("lblQuestionText")
            Dim lblType As Label = e.Item.FindControl("lblQuestionType")

            lblNum.Text = Q.QuestionNumber
            lblText.Text = Q.QuestionText
            lblType.Text = [Enum].GetName(GetType(Enums.enmQuestionType), Q.QuestionType)

        End If


    End Sub

    Private Sub btnAddAnother_Click(sender As Object, e As System.EventArgs) Handles btnAddAnother.Click
        SaveCurrentList()
        NewQuestion()
    End Sub
    Private Sub SaveCurrentList()
        If ValidPage() Then
            Dim Q As New Question(uctrlCreateQuestion.QuestionText, uctrlCreateQuestion.QuestionTypeBox.SelectedValue)
            objSurvey.AddQuestion(Q)
        End If
    End Sub
    Private Function ValidPage() As Boolean
        Return uctrlCreateQuestion.ValidPage()
    End Function
    Private Sub NewQuestion()
        uctrlCreateQuestion.ClearControls()
        LoadSurvey()
    End Sub
End Class