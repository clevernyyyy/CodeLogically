﻿Imports System.Data.SqlClient
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

End Module
