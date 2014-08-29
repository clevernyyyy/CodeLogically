Imports System
Imports System.Collections.Generic
Imports Microsoft.AspNet.SignalR
Imports System.Collections.Concurrent
Imports System.Threading.Tasks
Imports System.Linq

Namespace ChatLogically.Hubs

    Public Class User

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(value As String)
                m_Name = value
            End Set
        End Property
        Private m_Name As String
        Public Property ConnectionIds() As HashSet(Of String)
            Get
                Return m_ConnectionIds
            End Get
            Set(value As HashSet(Of String))
                m_ConnectionIds = value
            End Set
        End Property
        Private m_ConnectionIds As HashSet(Of String)
    End Class

    <Authorize> _
    Public Class ChatHub
        Inherits Hub

        ' References: 
        ' https://github.com/SignalR/SignalR/wiki/Hubs
        ' https://github.com/SignalR/Samples/blob/master/BasicChat/ChatWithTracking.cs
        ' https://github.com/davidfowl/MessengR/blob/master/MessengR/Hubs/Chat.cs

        Private Shared ReadOnly Users As New ConcurrentDictionary(Of String, User)(StringComparer.InvariantCultureIgnoreCase)

        Public Sub Send(message As String)

            Dim sender As String = Context.User.Identity.Name

            ' So, broadcast the sender, too.
            Clients.All.received(New With { _
                Key .sender = sender, _
                Key .message = message, _
                Key .isPrivate = False _
            })
        End Sub

        Public Sub Send(message As String, [to] As String)

            Dim receiver As User
            If Users.TryGetValue([to], receiver) Then

                Dim sender As User = GetUser(Context.User.Identity.Name)

                Dim allReceivers As IEnumerable(Of String)
                SyncLock receiver.ConnectionIds
                    SyncLock sender.ConnectionIds

                        allReceivers = receiver.ConnectionIds.Concat(sender.ConnectionIds)
                    End SyncLock
                End SyncLock

                For Each cid As Object In allReceivers
                    Clients.Client(cid).received(New With { _
                        Key .sender = sender.Name, _
                        Key .message = message, _
                        Key .isPrivate = True _
                    })
                Next
            End If
        End Sub

        Public Function GetConnectedUsers() As IEnumerable(Of String)




            Return Users.Where(Function(x)
                                   SyncLock x.Value.ConnectionIds
                                       Return Not x.Value.ConnectionIds.Contains(Context.ConnectionId, StringComparer.InvariantCultureIgnoreCase)
                                   End SyncLock

                               End Function).[Select](Function(x) x.Key)
        End Function

        Public Overrides Function OnConnected() As Task

            Dim userName As String = Context.User.Identity.Name
            Dim connectionId As String = Context.ConnectionId

            Dim user = Users.GetOrAdd(userName, Function() New User() With { _
                .Name = userName, _
                .ConnectionIds = New HashSet(Of String)() _
            })

            SyncLock user.ConnectionIds

                user.ConnectionIds.Add(connectionId)

                ' // broadcast this to all clients other than the caller
                ' Clients.AllExcept(user.ConnectionIds.ToArray()).userConnected(userName);

                ' Or you might want to only broadcast this info if this 
                ' is the first connection of the user
                If user.ConnectionIds.Count = 1 Then

                    Clients.Others.userConnected(userName)
                End If
            End SyncLock

            Return MyBase.OnConnected()
        End Function

        Public Overrides Function OnDisconnected(ByVal lStoppedCalled As Boolean) As Task

            Dim userName As String = Context.User.Identity.Name
            Dim connectionId As String = Context.ConnectionId

            Dim user As User
            Users.TryGetValue(userName, user)

            If user IsNot Nothing Then

                SyncLock user.ConnectionIds

                    user.ConnectionIds.RemoveWhere(Function(cid) cid.Equals(connectionId))

                    If Not user.ConnectionIds.Any() Then

                        Dim removedUser As User = Nothing
                        Users.TryRemove(userName, removedUser)

                        ' You might want to only broadcast this info if this 
                        ' is the last connection of the user and the user actual is 
                        ' now disconnected from all connections.
                        Clients.Others.userDisconnected(userName)
                    End If
                End SyncLock
            End If

            Return MyBase.OnDisconnected(lStoppedCalled)
        End Function

        Private Function GetUser(username As String) As User

            Dim user As User
            Users.TryGetValue(username, user)

            Return user
        End Function
    End Class
End Namespace



'Namespace Areas.ChatLogically.Hubs
'    Public Class ChatHub
'        Inherits Hub

'        Dim dic As ConcurrentDictionary(Of String, String) = New ConcurrentDictionary(Of String, String)

'        Public Sub Send(name As String, message As String)
'            Clients.All.broadcastMessage(name, message)
'        End Sub
'        Public Sub SendToSpecific(name As String, message As String, cto As String)
'            'Clients.Caller.broadcastMessage(name, message)
'            'Clients.Client(dic(cto)).broadcastMessage(name, message)

'            Clients.Caller.broadcastMessageUser(name, message, cto)
'            Clients.Client(dic(cto)).broadcastMessageUser(name, message)
'        End Sub
'        Public Sub Notify(name As String, id As String)
'            If dic.ContainsKey(name) Then
'                Clients.Caller.differentName()
'            Else
'                dic.TryAdd(name, id)
'                For Each entry As KeyValuePair(Of String, String) In dic
'                    Clients.Caller.online(entry.Key)
'                Next
'                Clients.Others.enters(name)
'            End If

'            'Dim objUser As User = GetUser()
'        End Sub
'        Public Overrides Function OnConnected() As Task
'            Dim name = (From x As KeyValuePair(Of String, String) In dic
'                       Where x.Value = Context.ConnectionId.ToString()
'                       Select x).FirstOrDefault
'            Dim s As String = ""

'            If Not name.Key Is Nothing Then
'                dic.TryAdd(name.Key, s)
'            End If
'            Return Clients.All.connected(name.Key)
'            Return Nothing
'        End Function
'        Public Overrides Function OnDisconnected(ByVal pblnTest As Boolean) As Task
'            Dim name = (From x As KeyValuePair(Of String, String) In dic
'                       Where x.Value = Context.ConnectionId.ToString()
'                       Select x).FirstOrDefault
'            Dim s As String = ""
'            'dic.TryRemove(name.Key, s)
'            'Return Clients.All.disconnected(name.Key)
'            Return Nothing
'        End Function

'        'Public Sub Hello()
'        '    Clients.All.Hello()
'        'End Sub
'    End Class
'End Namespace
