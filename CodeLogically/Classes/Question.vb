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
                objYN.QuestionText = Me.QuestionText
                objYN.AllowIDK = (Me.QuestionType = Enums.enmQuestionType.YesNoIDK)
                Me.QuestionControl = objYN

            Case Enums.enmQuestionType.SingleLine, Enums.enmQuestionType.MultiLine
                Dim objTI As New TextInput
                objTI.QuestionText = Me.QuestionText
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
    Public Property OptionOrder As Integer
    Public Sub New(cText As String, nOrder As Integer)
        Me.OptionText = cText
        Me.OptionOrder = nOrder
    End Sub

End Class
Public Class QuestionOptions
    Inherits Collection(Of QuestionOption)

End Class
Public Class Survey
    Public Questions As Questions
    Private nSurveyType As Integer = 1
    Private nSurveySubType As Integer = 0
    Private cSurveyName As String = ""

    Public Sub New(nSurveyType As Integer, nSurveySubType As Integer, cSurveyName As String)
        Questions = New Questions
    End Sub

    Public Sub LoadQuestions(dt As DataTable)
        Me.Questions = New Questions
        For Each dr As DataRow In dt.Rows
            Dim objQ As New Question(Me, dr.Item("cText"), dr.Item("nSurveyOptionControl"), Nothing)
            For Each drO As DataRow In FillOptions(objQ.QuestionType, objQ.QuestionNumber).Rows
                Dim objO As New QuestionOption(dr.Item("cOption"), dr.Item("nOrder"))
                objQ.QuestionOptions.Add(objO)
            Next
            Questions.Add(objQ)
        Next
    End Sub
    Public Sub AddQuestion(Q As Question)
        Q.QuestionNumber = Me.Questions.Count + 1
        Me.Questions.Add(Q)
    End Sub
    Public Sub LoadSurvey()

        Dim dtSurveyAnswers As DataTable = FillSurveyAnswers()
        Dim dtQuestions As DataTable = FillQuestions()

        If dtQuestions IsNot Nothing AndAlso dtQuestions.Rows.Count > 0 Then
            LoadQuestions(dtQuestions)
        End If
    End Sub
    Private Function FillSurveyAnswers() As DataTable
        Dim cmd = SqlCommand("Survey.usp_Get_SurveyAnswers")

        With cmd.Parameters
            .AddWithValue("@nUserNum", 1)
            .AddWithValue("@nSurveyType", nSurveyType)
            .AddWithValue("@nSurveySubType", nSurveySubType)
        End With

        Return FillDataTable(cmd)
    End Function
    Private Function FillQuestions() As DataTable
        Dim cmd = SqlCommand("LookUp.usp_Get_SurveyQuestions")

        With cmd.Parameters
            .AddWithValue("@nSurveyType", nSurveyType)
            .AddWithValue("@nSurveySubType", nSurveySubType)
        End With

        Return FillDataTable(cmd)
    End Function
    Private Function FillOptions(ByVal nSurveyOptionControl As Integer, ByVal nSurveyQuestion As Integer) As DataTable
        Dim cmd = SqlCommand("LookUp.usp_Get_SurveyOptions")

        With cmd.Parameters
            .AddWithValue("@nSurveyType", nSurveyType)
            .AddWithValue("@nSurveySubType", nSurveySubType)
            .AddWithValue("@nSurveyOptionControl", nSurveyOptionControl)
            .AddWithValue("@nSurveyQuestion", nSurveyQuestion)
        End With

        Return FillDataTable(cmd)
    End Function
    Public Sub SaveSurvey()

        SaveSurveyType()
        SaveSurveyText()
        SaveSurveyOption()

    End Sub
    Private Sub SaveSurveyType()
        Dim cmd = SqlCommand("Lookup.usp_Upsert_SurveyTypes")

        With cmd.Parameters
            .AddWithValue("@nSurveyType", nSurveyType)
            .AddWithValue("@nSurveySubType", nSurveySubType)
            .AddWithValue("@cDescription", cSurveyName)
            .AddWithValue("@lLocked", 0)
        End With

        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
        End Try
    End Sub
    Private Sub SaveSurveyText()

        Dim cmd = SqlCommand("Lookup.usp_BulkUpsert_SurveyText")

        Dim dtSurveyText As New DataTable
        With dtSurveyText.Columns
            .Add("nSurveyType", Type.GetType("System.Int16"))
            .Add("nSurveySubType", Type.GetType("System.Int16"))
            .Add("nSurveyQuestion", Type.GetType("System.Int16"))
            .Add("cText", Type.GetType("System.String"))
            .Add("nSurveyOptionControl", Type.GetType("System.Int16"))
        End With

        For Each q As Question In Questions
            Dim dr As DataRow = dtSurveyText.NewRow
            With dr
                .Item("nSurveyType") = nSurveyType
                .Item("nSurveySubType") = nSurveySubType
                .Item("nSurveyQuestion") = q.QuestionNumber
                .Item("cText") = q.QuestionText
                .Item("nSurveyOptionControl") = q.QuestionType
            End With

            dtSurveyText.Rows.Add(dr)
        Next

        With cmd.Parameters
            .AddWithValue("@nSurveyType", nSurveyType)
            .AddWithValue("@nSurveySubType", nSurveySubType)
            Dim tvp As SqlClient.SqlParameter = .AddWithValue("@SurveyText", dtSurveyText)
            tvp.SqlDbType = SqlDbType.Structured
            tvp.TypeName = "[LookUp].[SurveyText_Type]"
        End With

        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
        End Try
    End Sub
    Private Sub SaveSurveyOption()

        Dim cmd = SqlCommand("Lookup.usp_BulkUpsert_SurveyOption")

        Dim dtSurveyOption As New DataTable
        With dtSurveyOption.Columns
            .Add("nSurveyType", Type.GetType("System.Int16"))
            .Add("nSurveySubType", Type.GetType("System.Int16"))
            .Add("nSurveyOption", Type.GetType("System.Int16"))
            .Add("nSurveyQuestion", Type.GetType("System.Int16"))
            .Add("cOption", Type.GetType("System.String"))
            .Add("nOrder", Type.GetType("System.Int16"))
        End With

        For Each q As Question In Questions
            For Each o As QuestionOption In q.QuestionOptions
                Dim dr As DataRow = dtSurveyOption.NewRow
                With dr
                    .Item("nSurveyType") = nSurveyType
                    .Item("nSurveySubType") = nSurveySubType
                    .Item("nSurveyOption") = q.QuestionType
                    .Item("nSurveyQuestion") = q.QuestionNumber
                    .Item("cOption") = o.OptionText
                    .Item("nOrder") = o.OptionOrder
                End With

                dtSurveyOption.Rows.Add(dr)
            Next
        Next

        With cmd.Parameters
            .AddWithValue("@nSurveyType", nSurveyType)
            .AddWithValue("@nSurveySubType", nSurveySubType)
            Dim tvp As SqlClient.SqlParameter = .AddWithValue("@SurveyOption", dtSurveyOption)
            tvp.SqlDbType = SqlDbType.Structured
            tvp.TypeName = "[LookUp].[SurveyOption_Type]"
        End With

        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
        End Try
    End Sub
    Private Sub SaveSurveyAnswers()

        Dim cmd = SqlCommand("Survey.usp_BulkUpsert_SurveyAnswers")

        Dim dtSurveyAnswers As New DataTable
        With dtSurveyAnswers.Columns
            .Add("nUserNum", Type.GetType("System.Int16"))
            .Add("nSurveyType", Type.GetType("System.Int16"))
            .Add("nSurveySubType", Type.GetType("System.Int16"))
            .Add("nSurveyQuestion", Type.GetType("System.Int16"))
            .Add("cSaveValue", Type.GetType("System.Int16"))
        End With

        For Each q As Question In Questions
            Dim dr As DataRow = dtSurveyAnswers.NewRow
            With dr
                .Item("nUserNum") = 1
                .Item("nSurveyType") = nSurveyType
                .Item("nSurveySubType") = nSurveySubType
                .Item("nSurveyQuestion") = q.QuestionNumber
                '.Item("cSaveValue") = q.QuestionAnswer
            End With

            dtSurveyAnswers.Rows.Add(dr)
        Next

        With cmd.Parameters
            .AddWithValue("@nSurveyType", nSurveyType)
            .AddWithValue("@nSurveySubType", nSurveySubType)
            Dim tvp As SqlClient.SqlParameter = .AddWithValue("@SurveyAnswers", dtSurveyAnswers)
            tvp.SqlDbType = SqlDbType.Structured
            tvp.TypeName = "[Survey].[SurveyAnswers_Type]"
        End With

        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
        End Try
    End Sub
End Class

