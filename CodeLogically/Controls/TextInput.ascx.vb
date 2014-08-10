Public Class TextInput
    Inherits QuestionControl

    Public Overrides Property QuestionType As Enums.enmQuestionType
        Get
            Return MyBase.QuestionType
        End Get
        Set(value As Enums.enmQuestionType)
            MyBase.QuestionType = value
            If value = Enums.enmQuestionType.MultiLine Then
                MultiLine = True
            Else
                MultiLine = False
            End If
        End Set
    End Property

    Private Property _QuestionText As String
    Public Property QuestionText As String
        Get
            Return lblQuestionText.Text
        End Get
        Set(value As String)
            lblQuestionText.Text = value
        End Set
    End Property
    Private _MultiLine As Boolean = False
    Public Property MultiLine As Boolean
        Get
            Return _MultiLine
        End Get
        Set(value As Boolean)
            _MultiLine = value
            If value Then
                txtQuestionAnswer.TextMode = TextBoxMode.MultiLine
                txtQuestionAnswer.Style.Item("Height") = "100px;"
            Else
                txtQuestionAnswer.TextMode = TextBoxMode.SingleLine
            End If
        End Set
    End Property


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Public Overrides Function SaveAnswer() As Boolean
        Return True
    End Function
    Public Sub New()
        Me.txtQuestionAnswer = New TextBox
    End Sub
    Public Overrides Sub LoadQuestion(Q As Question)
        Me.QuestionText = Q.QuestionText
        Me.QuestionType = Q.QuestionType
        Me.MultiLine = (Q.QuestionType = Enums.enmQuestionType.MultiLine)
    End Sub
End Class