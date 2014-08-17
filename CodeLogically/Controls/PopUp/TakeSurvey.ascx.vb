Public Class TakeSurveyControl
    Inherits System.Web.UI.UserControl

    Private objSurvey As Survey
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session.Clear()
        End If
        objSurvey = HttpContext.Current.Session("Survey")
    End Sub
    Public Sub LoadSurvey(Optional ByVal objTakeSurvey As Survey = Nothing)
        If objTakeSurvey IsNot Nothing Then
            objSurvey = objTakeSurvey
            HttpContext.Current.Session("Survey") = objSurvey
        End If

        Dim collQuestions As Questions = objSurvey.Questions
        rptSurvey.DataSource = collQuestions
        rptSurvey.DataBind()
    End Sub

    Private Sub rptSurvey_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptSurvey.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Q As Question = e.Item.DataItem
            Dim ctrl As QuestionControl
            Select Case Q.QuestionType
                Case Enums.enmQuestionType.YesNo, Enums.enmQuestionType.YesNoIDK
                    ctrl = e.Item.FindControl("ctrlYesNoIDK")
                    ctrl.LoadQuestion(Q)
                    ctrl.Visible = True
                Case Enums.enmQuestionType.SingleLine, Enums.enmQuestionType.MultiLine
                    ctrl = e.Item.FindControl("ctrlTextInput")
                    ctrl.LoadQuestion(Q)
                    ctrl.Visible = True
                Case Enums.enmQuestionType.DropDown, Enums.enmQuestionType.MultiRadio
                    ctrl = DirectCast(e.Item.FindControl("ctrlMultipleChoice"), MultipleChoice)
                    ctrl.LoadQuestion(Q)
                    ctrl.Visible = True
                Case Enums.enmQuestionType.AgreeDisagree
                    ctrl = e.Item.FindControl("ctrlAgreeDisagree")
                    ctrl.LoadQuestion(Q)
                    ctrl.Visible = True
            End Select

        End If


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Session.Clear()
    End Sub

    Private Sub btnFinish_Click(sender As Object, e As System.EventArgs) Handles btnFinish.Click
        Session.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As System.EventArgs) Handles btnSave.Click

        Dim i As Integer = 0
        For Each item As RepeaterItem In rptSurvey.Items
            If item.ItemType = ListItemType.Item Or item.ItemType = ListItemType.AlternatingItem Then
                Dim ctrl As QuestionControl
                Dim ioption As Integer = 0
                Dim Q As Question = Nothing
                Q = objSurvey.Questions(i)

                Select Case Q.QuestionType
                    Case Enums.enmQuestionType.YesNo, Enums.enmQuestionType.YesNoIDK
                        ctrl = item.FindControl("ctrlYesNoIDK")
                    Case Enums.enmQuestionType.SingleLine, Enums.enmQuestionType.MultiLine
                        ctrl = item.FindControl("ctrlTextInput")
                    Case Enums.enmQuestionType.DropDown, Enums.enmQuestionType.MultiRadio
                        ctrl = DirectCast(item.FindControl("ctrlMultipleChoice"), MultipleChoice)
                        If ctrl IsNot Nothing Then
                            ctrl.QuestionType = Q.QuestionType
                        End If
                    Case Enums.enmQuestionType.AgreeDisagree
                        ctrl = item.FindControl("ctrlAgreeDisagree")
                        Q.QuestionAnswers = ctrl.Value
                End Select
                If Q.QuestionType <> Enums.enmQuestionType.AgreeDisagree Then
                    Q.QuestionAnswers.Add(ioption, ctrl.Value)
                End If
                i += 1
            End If
        Next
        objSurvey.SaveSurveyAnswers()
        Session.Clear()
    End Sub

End Class