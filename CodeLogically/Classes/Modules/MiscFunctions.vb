Imports System.Data.SqlClient
Module MiscFunctions

    Public Function NewConnection(Optional ByVal lLogin As Boolean = False) As SqlConnection
        Dim objConnections As New Connections
        If lLogin Then
            Return objConnections.NewCnnLogin
        Else
            Return objConnections.NewCnn
        End If
    End Function
    Public Function SqlCommand(commandText As String) As SqlCommand
        Dim cmd As New SqlCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = commandText
        cmd.Connection = NewConnection()
        Return cmd
    End Function
    Public Function AddEmptyRowToBegining(ByRef dtTable As DataTable, Optional ByVal cSortCol As String = "", Optional ByVal FixNulls As Boolean = True)
        Dim dr As DataRow = dtTable.NewRow

        dtTable.Rows.InsertAt(dr, 0)

        Return dtTable
    End Function
    Public Function FillDataTable(cmd As SqlCommand) As DataTable
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(cmd)
        Try
            cmd.Connection.Open()
            da.Fill(dt)
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
        End Try
        Return dt
    End Function
    Public Sub SetDataSource(ByVal pstrControl As DropDownList, _
    ByVal pdtStructure As DataTable, _
    ByVal pstrDataText As String, _
    ByVal pstrDataValue As String)

        Try
            'Set DataSource of DropDownList
            With pstrControl
                .Items.Clear()
                .SelectedIndex = -1
                .SelectedValue = Nothing
                .ClearSelection()
                .DataSource = pdtStructure
                .DataTextField = pstrDataText
                .DataValueField = pstrDataValue
                .DataBind()
            End With
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub SimplePopup(ByRef page As Page, ByVal strText As String, ByVal strTitle As String)
        Dim strJava As String = "SimplePopup('<div>" & strText & "</div>','" & strTitle & "');"

        ScriptManager.RegisterClientScriptBlock(page, page.GetType, "ErrorPopup", strJava, True)
    End Sub
    Public Function QuestionAllowsOptions(ByVal enmQuestionType As Enums.enmQuestionType)
        Select Case enmQuestionType
            Case Enums.enmQuestionType.AgreeDisagree, Enums.enmQuestionType.DropDown, Enums.enmQuestionType.MultiRadio
                Return True
            Case Else
                Return False
        End Select
    End Function
    Public Function NewSurveyID() As Integer
        Dim intReturn As Integer
        Dim cmd As SqlCommand = SqlCommand("[Survey].usp_Create_NewSurveyID")

        Try
            cmd.Connection.Open()
            intReturn = cmd.ExecuteScalar()
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
        End Try

        Return intReturn
    End Function
    Public Function LoginUser(pstrEmail As String) As DataRow
        Dim cmd As New SqlCommand("[Admin].usp_Login", NewConnection(True))
        cmd.Parameters.AddWithValue("@cEmail", pstrEmail)
        cmd.CommandType = CommandType.StoredProcedure
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter(cmd)
        Try
            cmd.Connection.Open()
            da.Fill(dt)
        Catch ex As Exception
        Finally
            cmd.Connection.Close()
        End Try
        If dt.Rows.Count = 1 Then
            Return dt.Rows(0)
        Else
            Return Nothing
        End If
    End Function
    Public Function ValidateUser(ByVal userName As String, ByVal passWord As String, ByRef objUser As User) As Boolean
        Dim lookupPassword As String

        lookupPassword = Nothing
        Dim drUser As DataRow
        ' Check for an invalid userName.
        ' userName  must not be set to nothing and must be between one and 50 characters.
        If ((userName Is Nothing)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If
        If ((userName.Length = 0) Or (userName.Length > 50)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If

        ' Check for invalid passWord.
        ' passWord must not be set to nothing and must be between one and 50 characters.
        If (passWord Is Nothing) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If
        If ((passWord.Length = 0) Or (passWord.Length > 50)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If

        Try
            drUser = LoginUser(userName)

            If drUser IsNot Nothing Then
                lookupPassword = drUser.Item("cPWD")
            End If
        Catch ex As Exception
            ' Add error handling here for debugging.
            ' This error message should not be sent back to the caller.
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " & ex.Message)
        End Try

        ' If no password found, return false.
        If (lookupPassword Is Nothing) Then
            ' You could write failed login attempts here to the event log for additional security.
            'Session("LoginError") = "Username not found"
            Return False
        End If
        ' Compare lookupPassword and input passWord by using a case-sensitive comparison.
        Dim cHashPassword As String = FormsAuthentication.HashPasswordForStoringInConfigFile(passWord, "MD5")
        If (String.Compare(lookupPassword, cHashPassword, False) = 0) Then
            objUser = New User(drUser)
            Return True
        Else
            'Session("LoginError") = "Incorrect Password"
            objUser = Nothing
            Return False
        End If

    End Function

End Module
