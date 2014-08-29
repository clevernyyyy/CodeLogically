Imports CodeLogically.ChatLogically.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Web.Security

Namespace ChatLogically.Controllers

    Public Class AccountController
        Inherits Controller

        Public Function Login() As ViewResult

            Return View()

        End Function

        <HttpPost> _
        <ActionName("Login")> _
        Public Function PostLogin(loginModel As LoginModel) As ActionResult

            If ModelState.IsValid Then

                FormsAuthentication.SetAuthCookie(loginModel.Name, True)
                Return RedirectToAction("signalrchat", "home")
            End If

            Return View(loginModel)
        End Function

        <HttpPost> _
        <ActionName("SignOut")> _
        Public Function PostSignOut() As ActionResult

            FormsAuthentication.SignOut()
            Return RedirectToAction("signalrchat", "home")
        End Function
    End Class
End Namespace