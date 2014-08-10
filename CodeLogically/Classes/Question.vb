Imports System.Collections.ObjectModel
Public Class Question
    Public Property QuestionNumber As Integer
    Public Property QuestionText As String
    Public Property QuestionType As Enums.enmQuestionType
    Public Property QuestionControl As QuestionControl
    Public Property QuestionOptions As QuestionOptions
    Private Property SurveyParent As Survey

    Public Sub New(objSurvey As Survey, cText As String, enmType As Enums.enmQuestionType, objOptions As QuestionOptions)
        Me.SurveyParent = objSurvey
        Me.QuestionText = cText
        Me.QuestionType = enmType
        Select Case Me.QuestionType
            Case Enums.enmQuestionType.YesNo, Enums.enmQuestionType.YesNoIDK
                Dim objYN As New YesNoIDK
                objYN.AllowIDK = (Me.QuestionType = Enums.enmQuestionType.YesNoIDK)
                Me.QuestionControl = objYN

            Case Enums.enmQuestionType.SingleLine, Enums.enmQuestionType.MultiLine
                Dim objTI As New TextInput
                objTI.MultiLine = (Me.QuestionType = Enums.enmQuestionType.MultiLine)
                Me.QuestionControl = objTI
        End Select
        Me.QuestionOptions = objOptions
    End Sub
    Public Sub New(cText As String, enmType As Enums.enmQuestionType)
        Me.QuestionText = cText
        Me.QuestionType = enmType
    End Sub
End Class
Public Class Questions
    Inherits Collection(Of Question)

End Class
Public Class QuestionOption
    Public Property OptionText As String
    Public Sub New(cText As String)
        Me.OptionText = cText
    End Sub
End Class
Public Class QuestionOptions
    Inherits Collection(Of QuestionOption)

End Class
Public Class Survey
    Public Questions As Questions
    Private nSurveyType As Integer = 1
    Private nSurveySubType As Integer = 0

    Public Sub New(nSurveyType As Integer, nSurveySubType As Integer)
        Questions = New Questions
    End Sub

    Public Sub Load(dt As DataTable)
        Me.Questions = New Questions
        For Each dr As DataRow In dt.Rows
            Dim objQ As New Question(Me, dr.Item("cText"), dr.Item("nSurveyOptionControl"), Nothing)
            Questions.Add(objQ)
        Next
    End Sub
    Public Sub AddQuestion(Q As Question)
        Q.QuestionNumber = Me.Questions.Count + 1
        Me.Questions.Add(Q)
    End Sub
End Class
