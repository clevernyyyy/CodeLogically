Public Class CreateNewSurvey
    Inherits System.Web.UI.UserControl

    Private objSurvey As Survey
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Survey") Is Nothing Then
                Dim intSurveyID As Integer = FillDataTable(SqlCommand("Lookup.usp_Get_NewSurvey")).Rows(0).Item("nSurveyID")
                objSurvey = New Survey(intSurveyID, 0, "Test Survey")
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
            'Dim pnlControl As Panel = e.Item.FindControl("pnlQuestionControl")
            lblNum.Text = Q.QuestionNumber
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
            End Select
            'pnlControl.Controls.Add(Q.QuestionControl)
            'upQuestions.Update()

        End If


    End Sub

    Private Sub btnAddAnother_Click(sender As Object, e As System.EventArgs) Handles btnAddAnother.Click
        OpenSurveyEditor()
        SaveCurrentList()
        NewQuestion()
    End Sub

    Private Sub OpenSurveyEditor()
        Dim strJava As String = "OpenSurveyEditor();"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenSurveyEditor", strJava, True)
    End Sub


    Private Sub SaveCurrentList()
        If ValidPage() Then
            Dim nQuestionType As Enums.enmQuestionType = uctrlCreateQuestion.QuestionTypeBox.SelectedValue
            Dim objOptions As QuestionOptions = Nothing
            If nQuestionType = Enums.enmQuestionType.DropDown Or nQuestionType = Enums.enmQuestionType.MultiRadio Then
                objOptions = New QuestionOptions
                    Dim txtOptions = From ri As RepeaterItem In uctrlCreateQuestion.OptionsRepeater.Items
                                     Where ri.ItemType = ListItemType.Item Or ri.ItemType = ListItemType.AlternatingItem
                                     Select DirectCast(ri.FindControl("ctrlUO"), UserOption).OptionText

                    If txtOptions.Count > 0 Then
                        Dim lstOptions As List(Of String) = txtOptions.ToList
                        For Each strOption In lstOptions
                            objOptions.Add(New QuestionOption(strOption, 0))
                        Next
                    End If
            End If
            Dim Q As New Question(objSurvey, uctrlCreateQuestion.QuestionText, nQuestionType, objOptions)
            objSurvey.AddQuestion(Q)
        End If
    End Sub
    Private Sub btnFinish_Click(sender As Object, e As System.EventArgs) Handles btnFinish.Click
        objSurvey.SaveSurvey()
    End Sub

    Private Function ValidPage() As Boolean
        Return uctrlCreateQuestion.ValidPage()
    End Function
    Private Sub NewQuestion()
        uctrlCreateQuestion.ClearControls()
        LoadSurvey()
    End Sub
End Class