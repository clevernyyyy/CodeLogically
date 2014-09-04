Imports Microsoft.AspNet.SignalR
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports CodeLogically.ChatRoom.HubCommon

Namespace ChatRoom
    Public Class ChatHub
        Inherits Hub
#Region "Properties"

        'Active users in the system
        Public Shared UsersOnline As New List(Of Users)()

#End Region

#Region "Hub Methods"

        ''' <summary>
        ''' Customer entering the system
        ''' </summary>
        ''' <param name="userName"></param> 
        Public Overrides Function OnConnected() As System.Threading.Tasks.Task
            AddPersonToGroup(Nothing)
            Return MyBase.OnConnected()
        End Function

        ''' <summary>
        ''' Added to the list of users
        ''' </summary>
        ''' <param name="userName"></param>
        Public Sub AddPersonToGroup(userName As String)
            Dim validUser As Boolean = True
            If userName Is Nothing Then
                userName = Context.Request.User.Identity.Name
                'Nav logged.
                If Not (userName.Length > 4) Then
                    validUser = False

                End If
            ElseIf userName.Length < 5 OrElse userName.Length > 10 Then
                Clients.Caller.SendErrorAlert("Username length must be between 5 and 10 characters!")
                validUser = False
            End If
            'If the user name is appropriate , then registers
            If validUser Then
                AddNewUser(userName)
            End If
            'Returns the users with
            Clients.All.onConnection(UsersOnline)


        End Sub

        ''' <summary>
        ''' Send a message to the Chat Room
        ''' </summary>
        ''' <param name="userName"></param>
        ''' <param name="msg"></param>
        Public Sub GlobalMessages(msg As String)
            Dim userName = UsersOnline.FirstOrDefault(Function(x) x.Connection = Context.ConnectionId)
            If userName IsNot Nothing Then
                Clients.AllExcept(Context.ConnectionId).sendToGlobal("(" & DateTime.Now.ToShortTimeString() & ") " & Convert.ToString(userName.Name), msg)
                Clients.Caller.sendToGlobal("(" & DateTime.Now.ToShortTimeString() & ") <span class=""SenderFormat"">" & Convert.ToString(userName.Name) & "</span>", msg)
            Else
                SendErrorMessage("To activate the chat features you must log into the system!")
            End If
        End Sub

        ''' <summary>
        ''' Customer leaving the system
        ''' </summary>
        Public Overrides Function OnDisconnected(ByVal lConnect As Boolean) As System.Threading.Tasks.Task
            'Clarifying users who escapes from the system ( called this method )
            RemovePersonFromGroup()
            Return MyBase.OnDisconnected(True)
        End Function

        ''' <summary>
        ''' Remove the user from the list
        ''' </summary>
        Public Sub RemovePersonFromGroup()
            Dim user = UsersOnline.FirstOrDefault(Function(x) x.Connection = Context.ConnectionId)
            If user IsNot Nothing Then
                UsersOnline.Remove(user)
                Clients.All.onDisconnection(Context.ConnectionId, user.Name)
            End If
        End Sub

        ''' <summary>
        ''' Send private message
        ''' </summary>
        ''' <param name="message">Message text</param>
        ''' <param name="toConnId">Send to</param>
        Public Sub SendPrivateMessage(message As String, toConnId As String)
            Dim Sender = UsersOnline.FirstOrDefault(Function(x) x.Connection = Context.ConnectionId)
            'It should not be, but what if , however,
            If Sender IsNot Nothing Then

                Clients.Client(toConnId).SendPrivateMessage(Sender.Connection, "(" & DateTime.Now.ToShortTimeString() & ") " & Convert.ToString(Sender.Name), message)
                'If sending to yourself.
                If toConnId <> Context.ConnectionId Then
                    Clients.Caller.SendPrivateMessage(toConnId, "(" & DateTime.Now.ToShortTimeString() & ") <span class=""SenderFormat"">" & Convert.ToString(Sender.Name) & "</span>", message)
                End If
            Else
                Clients.Caller.SendPrivateMessage(toConnId, "(" & DateTime.Now.ToShortTimeString() & ") <span style=""Color:Red"" class=""SenderFormat"">System</span>", "To send a message is logged!")
            End If

        End Sub

#End Region

#Region "Functions"

        ''' <summary>
        ''' Before granting a user name , or the user name has already been created. If there is - are making 
        ''' </summary>
        ''' <param name="userName"></param>
        ''' <returns></returns>
        Private Function ValidateUserName(userName As String, Ident As Integer) As String
            Dim user = UsersOnline.FirstOrDefault(Function(x) x.Name = userName)
            If user Is Nothing Then
                Return userName
            Else
                userName = userName.Remove(userName.Length - Ident.ToString().Length) & Ident
                Return ValidateUserName(userName, Ident + 1)
            End If
        End Function

        ''' <summary>
        ''' Add new customer
        ''' </summary>
        ''' <param name="userName"></param>
        Public Sub AddNewUser(userName As String)
            'Get user Id . guid format.
            Dim userID = Context.ConnectionId
            Dim user As New Users() With { _
                .Name = ValidateUserName(userName, 0), _
                .Connection = userID _
            }
            UsersOnline.Add(user)
        End Sub

        ''' <summary>
        ''' Error notification
        ''' </summary>
        ''' <param name="error">Error notification</param>
        Public Sub SendErrorMessage([error] As String)
            Clients.Caller.SendErrorMessage("Error", [error])
        End Sub

#End Region

    End Class
End Namespace