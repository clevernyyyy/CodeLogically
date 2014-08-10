﻿Public Class CreateNewSurvey
    Inherits System.Web.UI.UserControl

    Private objSurvey As Survey
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Survey") Is Nothing Then
                objSurvey = New Survey(1, 0, "Test Survey")
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
            'Dim lblText As Label = e.Item.FindControl("lblQuestionText")
            'Dim lblType As Label = e.Item.FindControl("lblQuestionType")
            Dim pnlControl As Panel = e.Item.FindControl("pnlQuestionControl")
            lblNum.Text = Q.QuestionNumber
            'lblText.Text = Q.QuestionText
            'lblType.Text = [Enum].GetName(GetType(Enums.enmQuestionType), Q.QuestionType)
            pnlControl.Controls.Add(Q.QuestionControl)


        End If


    End Sub

    Private Sub btnAddAnother_Click(sender As Object, e As System.EventArgs) Handles btnAddAnother.Click
        SaveCurrentList()
        NewQuestion()
    End Sub
    Private Sub SaveCurrentList()
        If ValidPage() Then
            Dim nQuestionType As Enums.enmQuestionType = uctrlCreateQuestion.QuestionTypeBox.SelectedValue
            Dim objOptions As QuestionOptions = Nothing
            If nQuestionType = Enums.enmQuestionType.DropDown Or nQuestionType = Enums.enmQuestionType.MultiRadio Then
                objOptions = New QuestionOptions
                If nQuestionType = Enums.enmQuestionType.DropDown Then
                    Dim txtOptions = From txtOption As UserOption In uctrlCreateQuestion.OptionsRepeater.Items
                                     Where txtOption.ID.Contains("ctrlUO") _
                                     AndAlso txtOption.OptionText.Trim <> ""
                                     Select txtOption.OptionText

                    If txtOptions.Count > 0 Then
                        Dim lstOptions As List(Of String) = txtOptions.ToList
                        For Each strOption In lstOptions
                            objOptions.Add(New QuestionOption(strOption, 0))
                        Next
                    End If
                ElseIf nQuestionType = Enums.enmQuestionType.MultiRadio Then
                    Dim txtOptions = From txtOption As TextBox In uctrlCreateQuestion.RadioButtonsPanel.Controls
                                     Where txtOption.ID.Contains("txtRadioText") _
                                     AndAlso txtOption.Text.Trim <> ""
                                     Select txtOption.Text

                    If txtOptions.Count > 0 Then
                        Dim lstOptions As List(Of String) = txtOptions.ToList
                        For Each strOption In lstOptions
                            objOptions.Add(New QuestionOption(strOption, 0))
                        Next
                    End If
                End If
            End If
            Dim Q As New Question(objSurvey, uctrlCreateQuestion.QuestionText, nQuestionType, objOptions)
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