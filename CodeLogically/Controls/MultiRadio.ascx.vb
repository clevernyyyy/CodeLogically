Public Class MultiRadio
    Inherits QuestionControl

    Private Property QuestionType As Enums.enmQuestionType = Enums.enmQuestionType.MultiRadio

    Public Property QuestionText As String

    'Private _AllowIDK As Boolean = False
    'Public Property AllowIDK As Boolean
    '    Get
    '        Return _AllowIDK
    '    End Get
    '    Set(value As Boolean)
    '        _AllowIDK = value
    '        If value Then
    '            rbtIDKMyBFFJill.Visible = True
    '        Else
    '            rbtIDKMyBFFJill.Visible = False
    '        End If
    '    End Set
    'End Property

    'ReadOnly Property YesID As String
    '    Get
    '        Return rbtYes.ClientID
    '    End Get
    'End Property
    'ReadOnly Property NoID As String
    '    Get
    '        Return rbtNo.ClientID
    '    End Get
    'End Property
    'ReadOnly Property IDKID As String
    '    Get
    '        Return rbtIDKMyBFFJill.ClientID
    '    End Get
    'End Property

    'Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    'End Sub


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

End Class