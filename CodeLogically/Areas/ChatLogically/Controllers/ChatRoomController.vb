Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace Areas.ChatLogically.Controllers

    <Authorize()> _
    Public Class ChatRoomController
        Inherits Controller

        ' GET: ChatLogically/ChatRoom
        Function SignalRChat() As ActionResult
            Return View()
        End Function
    End Class
End Namespace