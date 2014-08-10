Public Class MultipleChoice
    Inherits QuestionControl

    Private Property QuestionType As Enums.enmQuestionType = Enums.enmQuestionType.MultiRadio

    Public Property QuestionText As String


    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '   Add each radio button 
        'AddNewRaduiButton("MyRadio1")
        'AddNewRaduiButton("MyRadio2")
        'AddNewRaduiButton("MyRadio3")
        'AddNewRaduiButton("MyRadio4")
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

    End Sub
End Class