Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Optimization
Imports System.Web.Routing

Namespace ChatRoom
    ' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    ' visit http://go.microsoft.com/?LinkId=9394801

    Public Class MvcApplication
        Inherits System.Web.HttpApplication
        Protected Sub Application_Start()
            AreaRegistration.RegisterAllAreas()
            RouteConfig.RegisterRoutes(RouteTable.Routes)
            'RouteTable.Routes.MapHubs()
            WebApiConfig.Register(GlobalConfiguration.Configuration)
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
            BundleConfig.RegisterBundles(BundleTable.Bundles)
        End Sub
    End Class
End Namespace


'Public Class Global_asax
'    Inherits System.Web.HttpApplication

'    Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
'        ' Fires when the application is started
'        'ChatLogically.ChatLogicallyAreaRegistration.RegisterAllAreas()
'    End Sub

'    Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
'        ' Fires when the session is started
'    End Sub

'    Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
'        ' Fires at the beginning of each request
'    End Sub

'    Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
'        ' Fires upon attempting to authenticate the use
'    End Sub

'    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
'        ' Fires when an error occurs
'    End Sub

'    Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
'        ' Fires when the session ends
'    End Sub

'    Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
'        ' Fires when the application ends
'    End Sub

'End Class