Imports System.Collections.ObjectModel
Public Class Question
    Public Property QuestionNumber As Integer
    Public Property QuestionText As String
    Public Property QuestionType As Enums.enmQuestionType
    Public Property QuestionControl As QuestionControl
    Private Property SurveyParent As Survey

    Public Sub New(objSurvey As Survey, nQuestionNumber As Integer, cText As String, enmType As Enums.enmQuestionType)
        Me.SurveyParent = objSurvey
        Me.QuestionText = cText
        Me.QuestionType = enmType
        Select Case Me.QuestionType
            Case Enums.enmQuestionType.YesNoIDK
                Me.QuestionControl = New YesNoIDK
            Case Enums.enmQuestionType.SingleLine, Enums.enmQuestionType.MultiLine
                Dim objTI As New TextInput
                objTI.MultiLine = (Me.QuestionType = Enums.enmQuestionType.MultiLine)
                Me.QuestionControl = objTI
        End Select
    End Sub

End Class
Public Class Questions
    Inherits Collection(Of Question)

End Class
Public Class Survey
    Private collQuestions As Questions
    Private nSurveyType As Integer
    Private nSurveySubType As Integer

    Public Sub New(dt As DataTable)
        Me.collQuestions = New Questions
        For Each dr As DataRow In dt.Rows
            Dim objQ As New Question(Me, dr.Item("nSurveyQuestion"), dr.Item("cText"), dr.Item("nSurveyOptionControl"))
            collQuestions.Add(objQ)
        Next
    End Sub
End Class
