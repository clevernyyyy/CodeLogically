Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http

Namespace ChatRoom
    Public NotInheritable Class WebApiConfig
        Private Sub New()
        End Sub
        Public Shared Sub Register(config As HttpConfiguration)
            config.Routes.MapHttpRoute(name:="DefaultApi", routeTemplate:="api/{controller}/{id}", defaults:=New With { _
                Key .id = RouteParameter.[Optional] _
            })
        End Sub
    End Class
End Namespace