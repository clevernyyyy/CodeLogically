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
        Get
            Return lblQuestionText.Text
        End Get
        Set(value As String)
            lblQuestionText.Text = value
        End Set
    End Property


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
        Me.QuestionText = Q.QuestionText
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
                AddNewRadioButton(O.OptionOrder, O.OptionText, Q.QuestionNumber)
            Next
        End If
    End Sub
    Private Sub AddNewRadioButton(ByVal name As String, ByVal cText As String, ByVal QNumber As Integer)

        '   Create a new radio button 
        Dim MyRadioButton As New RadioButton

        With MyRadioButton
            .ID = "txtRadioText" & name.ToString
            .AutoPostBack = False
            .Text = cText
            .GroupName = "RadiosQuestion" & QNumber.ToString
        End With
        Dim rbl As RadioButtonList = FindControl("rblRadioButtons")
        rbl.Controls.Add(MyRadioButton)
    End Sub
    Public Sub New()
        Me.ddlOptions = New DropDownList
        Me.pnlRadioButtons = New Panel
        Me.lblQuestionText = New Label
    End Sub
End Class