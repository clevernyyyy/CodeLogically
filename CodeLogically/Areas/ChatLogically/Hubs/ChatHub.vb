Imports System
Imports System.Collections.Generic
Imports Microsoft.AspNet.SignalR
Imports System.Collections.Concurrent
Imports System.Threading.Tasks
Namespace Areas.ChatLogically.Hubs
    Public Class ChatHub
        Inherits Hub

        Dim dic As ConcurrentDictionary(Of String, String) = New ConcurrentDictionary(Of String, String)

        Public Sub Send(name As String, message As String)
            Clients.All.broadcastMessage(name, message)
        End Sub
        Public Sub SendToSpecific(name As String, message As String, cto As String)
            Clients.Caller.broadcastMessage(name, message)
            Clients.Client(dic(cto)).broadcastMessage(name, message)
        End Sub
        Public Sub Notify(name As String, id As String)
            If dic.ContainsKey(name) Then
                Clients.Caller.differentName()
            Else
                dic.TryAdd(name, id)
                For Each entry As KeyValuePair(Of String, String) In dic
                    Clients.Caller.online(entry.Key)
                Next
                Clients.Others.enters(name)
            End If
        End Sub
        Public Overrides Function OnConnected() As Task
            Dim name = (From x As KeyValuePair(Of String, String) In dic
                       Where x.Value = Context.ConnectionId.ToString()
                       Select x).FirstOrDefault
            Dim s As String = ""
            dic.TryRemove(name.Key, s)
            Return Clients.All.disconnected(name.Key)
        End Function

        Public Sub Hello()
            Clients.All.Hello()
        End Sub
    End Class
End Namespace
