Imports System.Collections.ObjectModel
Public Class Question
    Public Property QuestionNumber As Integer
    Public Property QuestionText As String
    Public Property QuestionType As Enums.enmQuestionType
    Public Property QuestionControl As QuestionControl
    Public Property QuestionOptions As QuestionOptions
    Public Property QuestionAnswers As Dictionary(Of Integer, String)
    Private Property SurveyParent As Survey

    Public Sub New(objSurvey As Survey, cText As String, enmType As Enums.enmQuestionType, objOptions As QuestionOptions, dicQuestionAnswers As Dictionary(Of Integer, String))
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
            Case Enums.enmQuestionType.DropDown, Enums.enmQuestionType.MultiRadio
                Dim objMC As New MultipleChoice
                objMC.QuestionText = Me.QuestionText
                objMC.QuestionType = Me.QuestionType
                Me.QuestionControl = objMC
            Case Enums.enmQuestionType.AgreeDisagree
                Dim objAD As New AgreeDisagree
                objAD.QuestionType = Me.QuestionType
                Me.QuestionControl = objAD
        End Select
        Me.QuestionOptions = objOptions
        Me.QuestionAnswers = dicQuestionAnswers
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
    Public Function ToDataTable() As DataTable
        Dim dt As New DataTable
        For Each p As Reflection.PropertyInfo In GetType(QuestionOption).GetProperties()
            Dim dc As New DataColumn(p.Name)
            dt.Columns.Add(dc)
        Next
        For Each Q As QuestionOption In Me
            Dim dr As DataRow = dt.NewRow
            For Each p As Reflection.PropertyInfo In GetType(QuestionOption).GetProperties()
                dr.Item(p.Name) = p.GetValue(Q, Nothing)
            Next
            dt.Rows.Add(dr)
        Next
        Return dt
    End Function
    Public Overloads Function Contains(ByVal cString As String) As Boolean
        Dim Q = From Qs As QuestionOption In Me
                Where Qs.OptionText = cString
                Select Qs

        If Q.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
Public Class Survey
    Public Questions As Questions
    Public ID As Integer = 0
    Public Type As Integer = 0
    Public Title As String = ""
    Public UserNum As Integer = 1
    Public Created As DateTime
    Public Locked As Boolean

    Public Sub New(pnID As Integer, pnType As Integer, pcTitle As String, pnUserNum As Integer, pdCreated As DateTime, Optional plLocked As Boolean = False)
        Questions = New Questions
        Me.ID = pnID
        Me.Type = pnType
        Me.Title = pcTitle
        Me.UserNum = pnUserNum
        Me.Created = pdCreated
        Me.Locked = plLocked
    End Sub

    Sub New(ByVal drSurvey As DataRow)
        With drSurvey
            Me.ID = .Item("nSurveyIDpe")
            Me.Type = .Item("nSurveyType")
            Me.Title = .Item("cTitle")
            Me.UserNum = .Item("nUserNum")
            Me.Created = .Item("dCreated")
            Me.Locked = .Item("lLocked")
        End With
        Questions = New Questions
    End Sub

    Public Sub LoadQuestions(dt As DataTable)
        Me.Questions = New Questions
        For Each dr As DataRow In dt.Rows
            Dim dicQuestionAnswers = New Dictionary(Of Integer, String)
            Dim objQ As New Question(Me, dr.Item("cText"), dr.Item("nOptionControlType"), New QuestionOptions, dicQuestionAnswers)
            objQ.QuestionNumber = dr.Item("nQuestionNumber")
            For Each drO As DataRow In FillOptions(objQ.QuestionNumber).Rows
                Dim objO As New QuestionOption(drO.Item("cOption"), drO.Item("nOrder"))
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

        'Dim dtSurveyAnswers As DataTable = FillSurveyAnswers()
        Dim dtQuestions As DataTable = FillQuestions()

        If dtQuestions IsNot Nothing AndAlso dtQuestions.Rows.Count > 0 Then
            LoadQuestions(dtQuestions)
        End If
    End Sub
    Private Function FillSurveyAnswers() As DataTable
        Dim cmd = SqlCommand("Survey.usp_Get_SurveyAnswers")

        With cmd.Parameters
            .AddWithValue("@nSurveyID", ID)
            .AddWithValue("@nUserNum", UserNum)
        End With

        Return FillDataTable(cmd)
    End Function
    Private Function FillQuestions() As DataTable
        Dim cmd = SqlCommand("Survey.usp_Get_SurveyQuestions")

        With cmd.Parameters
            .AddWithValue("@nSurveyID", ID)
        End With

        Return FillDataTable(cmd)
    End Function
    Private Function FillOptions(ByVal nQuestionNumber As Integer) As DataTable
        Dim cmd = SqlCommand("Survey.usp_Get_SurveyOptions")

        With cmd.Parameters
            .AddWithValue("@nSurveyID", ID)
            .AddWithValue("@nQuestionNumber", nQuestionNumber)
        End With

        Return FillDataTable(cmd)
    End Function
    Public Sub SaveSurvey()
        If Questions.Count > 0 Then
            If ID = 0 Then
                ID = NewSurveyID()
            End If
            SaveSurveyType()
            SaveSurveyQuestions()
            SaveSurveyOption()
        End If
    End Sub
    Private Sub SaveSurveyType()
        Dim cmd = SqlCommand("Survey.usp_Upsert_Survey")

        With cmd.Parameters
            .AddWithValue("@nSurveyID", ID)
            .AddWithValue("@nSurveyType", Type)
            .AddWithValue("@cTitle", Title)
            .AddWithValue("@nUserNum", UserNum)
            .AddWithValue("@lLocked", Locked)
        End With

        Try
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
        End Try
    End Sub
    Private Sub SaveSurveyQuestions()

        Dim cmd = SqlCommand("Survey.usp_BulkUpsert_SurveyQuestions")

        Dim dtQuestions As New DataTable
        With dtQuestions.Columns
            .Add("nSurveyID", System.Type.GetType("System.Int16"))
            .Add("nQuestionNumber", System.Type.GetType("System.Int16"))
            .Add("cText", System.Type.GetType("System.String"))
            .Add("nOptionControlType", System.Type.GetType("System.Int16"))
        End With

        For Each q As Question In Questions
            Dim dr As DataRow = dtQuestions.NewRow
            With dr
                .Item("nSurveyID") = ID
                .Item("nQuestionNumber") = q.QuestionNumber
                .Item("cText") = q.QuestionText
                .Item("nOptionControlType") = q.QuestionType
            End With

            dtQuestions.Rows.Add(dr)
        Next

        With cmd.Parameters
            .AddWithValue("@nSurveyID", ID)
            Dim tvp As SqlClient.SqlParameter = .AddWithValue("@SurveyQuestions", dtQuestions)
            tvp.SqlDbType = SqlDbType.Structured
            tvp.TypeName = "[Survey].[SurveyQuestions_Type]"
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

        Dim cmd = SqlCommand("Survey.usp_BulkUpsert_SurveyOption")

        Dim dtSurveyOption As New DataTable
        With dtSurveyOption.Columns
            .Add("nSurveyID", System.Type.GetType("System.Int16"))
            .Add("nQuestionNumber", System.Type.GetType("System.Int16"))
            .Add("nOptionControlType", System.Type.GetType("System.Int16"))
            .Add("cOption", System.Type.GetType("System.String"))
            .Add("nOrder", System.Type.GetType("System.Int16"))
        End With

        For Each q As Question In Questions
            If q.QuestionOptions IsNot Nothing Then
                For Each o As QuestionOption In q.QuestionOptions
                    Dim dr As DataRow = dtSurveyOption.NewRow
                    With dr
                        .Item("nSurveyID") = ID
                        .Item("nQuestionNumber") = q.QuestionNumber
                        .Item("nOptionControlType") = q.QuestionType
                        .Item("cOption") = o.OptionText
                        .Item("nOrder") = o.OptionOrder
                    End With

                    dtSurveyOption.Rows.Add(dr)
                Next
            End If
        Next
        If dtSurveyOption.Rows.Count > 0 Then
            With cmd.Parameters
                .AddWithValue("@nSurveyID", ID)
                Dim tvp As SqlClient.SqlParameter = .AddWithValue("@SurveyOption", dtSurveyOption)
                tvp.SqlDbType = SqlDbType.Structured
                tvp.TypeName = "[Survey].[SurveyOption_Type]"
            End With

            Try
                cmd.Connection.Open()
                cmd.ExecuteNonQuery()
            Catch ex As Exception
            Finally
                cmd.Connection.Close()
            End Try
        End If
    End Sub
    Private Sub SaveSurveyAnswers()

        Dim cmd = SqlCommand("Survey.usp_BulkUpsert_Survey_Answers")

        Dim dtSurveyAnswers As New DataTable
        With dtSurveyAnswers.Columns
            .Add("nSurveyID", System.Type.GetType("System.Int16"))
            .Add("nUserNum", System.Type.GetType("System.Int16"))
            .Add("nQuestionNumber", System.Type.GetType("System.Int16"))
            .Add("cOption", System.Type.GetType("System.String"))
            .Add("cSaveValue", System.Type.GetType("System.String"))
        End With

        For Each q As Question In Questions
            Dim dr As DataRow = dtSurveyAnswers.NewRow
            With dr
                .Item("nSurveyID") = ID
                .Item("nUserNum") = UserNum
                .Item("nQuestionNumber") = q.QuestionNumber
                '.Item("cOption") = q.QuestionAnswer
                '.Item("cSaveValue") = q.QuestionAnswer
            End With

            dtSurveyAnswers.Rows.Add(dr)
        Next

        With cmd.Parameters
            .AddWithValue("@nSurveyID", ID)
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

