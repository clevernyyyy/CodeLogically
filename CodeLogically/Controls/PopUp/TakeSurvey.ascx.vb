Public Class TakeSurveyControl
    Inherits System.Web.UI.UserControl

    Private objSurvey As Survey
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Survey") Is Nothing Then
                'Throw New Exception
            Else
                objSurvey = Session("Survey")
                LoadSurvey()
            End If
        Else
            objSurvey = Session("Survey")
        End If
    End Sub
    Private Sub LoadSurvey()
        Dim collQuestions As Questions = objSurvey.Questions
        rptSurvey.DataSource = collQuestions
        rptSurvey.DataBind()
    End Sub

    Private Sub rptSurvey_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.RepeaterItemEventArgs) Handles rptSurvey.ItemDataBound
        If e.Item.ItemType = ListItemType.Item Or e.Item.ItemType = ListItemType.AlternatingItem Then
            Dim Q As Question = e.Item.DataItem
            Dim ctrl As QuestionControl
            'pnlControl.Controls.Clear()
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
                    ctrl = e.Item.FindControl("ctrlMultipleChoice")
                    ctrl.LoadQuestion(Q)
                    ctrl.Visible = True
                Case Enums.enmQuestionType.AgreeDisagree
                    ctrl = e.Item.FindControl("ctrlAgreeDisagree")
                    ctrl.LoadQuestion(Q)
                    ctrl.Visible = True
            End Select
            'pnlControl.Controls.Add(Q.QuestionControl)
            'upQuestions.Update()

        End If


    End Sub

End Class