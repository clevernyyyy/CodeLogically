﻿Public Class TextInput
    Inherits QuestionControl

    Private Property _QuestionType As Enums.enmQuestionType
    Public Overrides Property QuestionType As Enums.enmQuestionType
        Get
            Return _QuestionType
        End Get
        Set(value As Enums.enmQuestionType)
            _QuestionType = value
            If value = Enums.enmQuestionType.SingleLine Then
                MultiLine = False
            Else
                MultiLine = True
            End If
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
End Class