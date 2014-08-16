Public Class YesNoIDK
    Inherits QuestionControl


    Public Overrides Property QuestionType As Enums.enmQuestionType
        Get
            Return MyBase.QuestionType
        End Get
        Set(value As Enums.enmQuestionType)
            MyBase.QuestionType = value
            If value = Enums.enmQuestionType.YesNoIDK Then
                AllowIDK = True
            Else
                AllowIDK = False
            End If
        End Set
    End Property
    Private _AllowIDK As Boolean = False
    Public Property AllowIDK As Boolean
        Get
            Return _AllowIDK
        End Get
        Set(value As Boolean)
            _AllowIDK = value
            If value Then
                rbtIDKMyBFFJill.Visible = True
            Else
                rbtIDKMyBFFJill.Visible = False
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
    ReadOnly Property YesID As String
        Get
            Return rbtYes.ClientID
        End Get
    End Property
    ReadOnly Property NoID As String
        Get
            Return rbtNo.ClientID
        End Get
    End Property
    ReadOnly Property IDKID As String
        Get
            Return rbtIDKMyBFFJill.ClientID
        End Get
    End Property

    Protected Overloads Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public Overrides Function SaveAnswer() As Boolean
        Return True
    End Function
    Public Sub New()
        Me.rbtIDKMyBFFJill = New HtmlInputRadioButton
        Me.rbtNo = New HtmlInputRadioButton
        Me.rbtYes = New HtmlInputRadioButton
        Me.lblQuestionText = New Label
    End Sub
    Public Overrides Sub LoadQuestion(Q As Question)
        Me.QuestionType = Q.QuestionType
        Me.AllowIDK = Q.QuestionType = Enums.enmQuestionType.YesNoIDK
        Me.QuestionText = Q.QuestionText
    End Sub
End Class