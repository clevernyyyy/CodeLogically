Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Security

Namespace ChatRoom.Controllers
    Public Class AccountController
        Inherits Controller
        '
        ' GET: /Account/

        Public Function Index() As ActionResult
            Return View()
        End Function

        Public Function Login(id As String) As ActionResult
            If id.Length > 4 AndAlso id.Length < 11 Then
                FormsAuthentication.SetAuthCookie(id, False)
            End If
            Return Redirect("~/Account/Index")
        End Function

        Public Function SignOut() As ActionResult
            FormsAuthentication.SignOut()
            Return Redirect("~/Account/Index")
        End Function


    End Class
End Namespace