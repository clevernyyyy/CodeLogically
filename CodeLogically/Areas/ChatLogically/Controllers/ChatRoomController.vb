Imports System.Web.Mvc

Namespace Areas.ChatLogically.Controllers
    Public Class ChatRoomController
        Inherits Controller

        ' GET: ChatLogically/ChatRoom
        Function SignalRChat() As ActionResult
            Return View()
        End Function
    End Class
End Namespace