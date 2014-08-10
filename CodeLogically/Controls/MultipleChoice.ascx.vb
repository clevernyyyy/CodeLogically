Public Class MultipleChoice
    Inherits QuestionControl

    Public Overrides Property QuestionType As Enums.enmQuestionType
        Get
            Return MyBase.QuestionType
        End Get
        Set(value As Enums.enmQuestionType)
            MyBase.QuestionType = value
            If value = Enums.enmQuestionType.DropDown Then
                ddlOptions.Visible = True
                pnlRadioButtons.Visible = False
            Else
                pnlRadioButtons.Visible = True
                ddlOptions.Visible = False
            End If
        End Set
    End Property

    Public Property QuestionText As String


    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub MyRadioButton_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        '   Convert the Sender object into a radio button 
        Dim ClickedRadioButton As RadioButton = DirectCast(sender, RadioButton)

        '   Display the radio button name
        MsgBox(String.Format("Radio Button {0} has been Updated!", ClickedRadioButton.ID))

    End Sub

    Public Overrides Function SaveAnswer() As Boolean
        Return True
    End Function
    Public Overrides Sub LoadQuestion(Q As Question)
        Me.QuestionType = Q.QuestionType
        If Me.QuestionType = Enums.enmQuestionType.DropDown Then
            Q.QuestionOptions.Add(New QuestionOption("", 0))
            Dim dvOptions As New DataView(Q.QuestionOptions.ToDataTable())
            dvOptions.Sort = "OptionOrder"
            ddlOptions.DataSource = dvOptions
            ddlOptions.DataMember = "OptionText"
            ddlOptions.DataValueField = "OptionText"
            ddlOptions.DataBind()
        ElseIf Me.QuestionType = Enums.enmQuestionType.MultiRadio Then
            For Each O As QuestionOption In Q.QuestionOptions
                AddNewRadioButton(O.OptionOrder, O.OptionText)
            Next
        End If
    End Sub
    Private Sub AddNewRadioButton(ByVal name As String, ByVal cText As String)

        '   Create a new radio button 
        Dim MyRadioButton As New RadioButton

        With MyRadioButton
            .ID = "txtRadioText" & name.ToString
            .AutoPostBack = False
            .Text = cText
        End With

        FindControl("pnlRadioButtons").Controls.Add(MyRadioButton)
    End Sub

End Class