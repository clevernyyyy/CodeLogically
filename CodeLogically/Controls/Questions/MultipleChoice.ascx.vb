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
                'Place.Visible = False
                'rblRadioButtons.Visible = False
            Else
                'Place.Visible = True
                'rblRadioButtons.Visible = True
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
            If Q.QuestionOptions.Contains("") = False Then
                Q.QuestionOptions.Add(New QuestionOption("", 0))
            End If
            Dim dvOptions As New DataView(Q.QuestionOptions.ToDataTable())
            dvOptions.Sort = "OptionOrder"
            ddlOptions.DataSource = dvOptions
            ddlOptions.DataMember = "OptionText"
            ddlOptions.DataValueField = "OptionText"
            ddlOptions.DataBind()
        ElseIf Me.QuestionType = Enums.enmQuestionType.MultiRadio Then
            Place.Controls.Clear()
            For Each O As QuestionOption In Q.QuestionOptions
                Dim myRB As HtmlInputRadioButton = New HtmlInputRadioButton()
                'This works and aligns left, but doesn't get the actual text to seem to work
                myRB.Attributes.Add("style", "float:left;")
                Place.Controls.Add(myRB)

                Dim span As HtmlGenericControl = New HtmlGenericControl("span")
                span.InnerHtml = O.OptionText + "</br>"
                span.Attributes.Add("class", "smallfont")
                span.Attributes.Add("style", "align:left;")
                Place.Controls.Add(span)

                'AddNewRadioButton(O.OptionOrder, O.OptionText, Q.QuestionNumber)
            Next
        End If
    End Sub
    Private Sub AddNewRadioButton(ByVal name As String, ByVal cText As String, ByVal QNumber As Integer)

        ''   Create a new radio button 
        'Dim MyRadioButton As New RadioButton

        'With MyRadioButton
        '    .ID = "txtRadioText" & name.ToString
        '    .AutoPostBack = False
        '    .Text = cText
        '    .GroupName = "RadiosQuestion" & QNumber.ToString
        'End With

        Dim li As New ListItem(cText)
        'rblRadioButtons.Items.Add(li)
        
        'rbl.Controls.Add(MyRadioButton)
    End Sub
    Public Sub New()
        Me.ddlOptions = New DropDownList
        'Me.rblRadioButtons = New RadioButtonList
        Me.Place = New PlaceHolder
        Me.lblQuestionText = New Label
    End Sub
End Class