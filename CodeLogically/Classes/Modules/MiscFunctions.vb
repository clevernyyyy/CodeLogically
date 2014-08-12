Imports System.Data.SqlClient
Module MiscFunctions

    Public Function NewConnection() As SqlConnection
        Dim objConnections As New Connections
        Return objConnections.NewCnn
    End Function
    Public Function SqlCommand(commandText As String) As SqlCommand
        Dim cmd As New SqlCommand(commandText, NewConnection)
        cmd.CommandType = CommandType.StoredProcedure
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
End Module
