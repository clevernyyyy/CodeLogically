Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace ChatRoom.Controllers
    Public Class HomeController
        Inherits Controller
        '
        ' GET: /Home/

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function GetPrivateMessageDialog(Id As String) As ActionResult
            If Id IsNot Nothing Then

                Dim userName = ChatHub.UsersOnline.FirstOrDefault(Function(x) x.Connection = Id)
                ViewBag.ConnectionId = Id
                ViewBag.UserName = userName.Name
                Return View()
            Else
                Return Nothing
            End If

        End Function

    End Class
End Namespace