Imports System.Data.SqlClient
Public MustInherit Class CreateQuestion
    Inherits System.Web.UI.UserControl

    Public ParentSurvey As Survey

    Public Function NewConnection() As SqlConnection
        Dim objConnections As New Connections
        Return objConnections.NewCnn
    End Function
    Public Function SqlCommand(commandText As String) As SqlCommand
        Dim cmd As New SqlCommand(commandText, NewConnection)
        cmd.CommandType = CommandType.StoredProcedure
        Return cmd
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Public MustOverride Function SaveQuestion() As Boolean

End Class
