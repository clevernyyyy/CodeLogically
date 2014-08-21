Imports Microsoft.Owin
Imports Owin

<Assembly: OwinStartup(GetType(Areas.ChatLogically.Startup))> 
Namespace Areas.ChatLogically
    Public Class Startup
        Public Sub Configuration(app As IAppBuilder)
            app.MapSignalR()
        End Sub
    End Class
End Namespace