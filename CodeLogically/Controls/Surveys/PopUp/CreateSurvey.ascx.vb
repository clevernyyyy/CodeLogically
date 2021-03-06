﻿Public Class CreateNewSurvey
    Inherits System.Web.UI.UserControl

    Public objSurvey As Survey
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Session("Survey") IsNot Nothing Then
                objSurvey = Session("Survey")
                NewQuestion()
            End If
        Else
            objSurvey = Session("Survey")
        End If

        'Commenting out this script until I can fix the AJAX issue.
        AddNewQuestionJS(btnAddAnother)
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
            lblNum.Text = ("#" + CStr(Q.QuestionNumber) + ".)  ")
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

    Private Sub btnAddAnother_Click(sender As Object, e As System.EventArgs) Handles btnAddAnother.Click
        OpenSurveyEditor()
        SaveCurrentList()
        NewQuestion()
    End Sub

    Private Sub OpenSurveyEditor()
        Dim strJava As String = "OpenSurveyEditorFast();"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "OpenSurveyEditorFast", strJava, True)
    End Sub

    Public Sub SaveCurrentList()
        If ValidPage() Then ' And Not IsPostBack() Then     (Add when I get AJAX working)
            Dim nQuestionType As Enums.enmQuestionType = uctrlCreateQuestion.QuestionTypeBox.SelectedValue
            Dim objOptions As QuestionOptions = Nothing
            If QuestionAllowsOptions(nQuestionType) Then
                objOptions = New QuestionOptions
                Dim txtOptions = From ri As RepeaterItem In uctrlCreateQuestion.OptionsRepeater.Items
                                 Where ri.ItemType = ListItemType.Item Or ri.ItemType = ListItemType.AlternatingItem
                                 Select DirectCast(ri.FindControl("ctrlUO"), UserOption).OptionText

                If txtOptions.Count > 0 Then
                    Dim lstOptions As List(Of String) = txtOptions.ToList
                    For Each strOption In lstOptions
                        'Don't add an option that was never entered
                        If strOption <> "" Then
                            objOptions.Add(New QuestionOption(strOption, 0))
                        End If
                    Next
                End If
            End If
            Dim dicQuestionAnswers = New Dictionary(Of Integer, String)
            Dim Q As New Question(objSurvey, uctrlCreateQuestion.QuestionText, nQuestionType, objOptions, dicQuestionAnswers)
            objSurvey.AddQuestion(Q)
        End If
    End Sub
    Private Sub btnFinish_Click(sender As Object, e As System.EventArgs) Handles btnFinish.Click
        objSurvey.Title = txtTitle.Text.Trim()
        objSurvey.SaveSurvey()
        Session.Clear()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As System.EventArgs) Handles btnCancel.Click
        Session.Clear()
    End Sub

    Private Function ValidPage() As Boolean
        Return uctrlCreateQuestion.ValidPage()
    End Function
    Public Sub NewQuestion()
        uctrlCreateQuestion.ClearControls()
        LoadSurvey()
    End Sub


#Region "JavaScript"
    Private Sub AddNewQuestionJS(ByVal btn As Button)
        Dim strJava As String = ""

        'Make the AJAX call
        strJava = "javascript:addQuestion();"
        btn.Attributes.Add("onclick", strJava)

    End Sub
#End Region

End Class