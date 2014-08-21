Imports System.Web.Mvc

Namespace Areas.ChatLogically
    Public Class ChatLogicallyAreaRegistration
        Inherits AreaRegistration

        Public Overrides ReadOnly Property AreaName() As String
            Get
                Return "ChatLogically"
            End Get
        End Property

        Public Overrides Sub RegisterArea(ByVal context As AreaRegistrationContext)
            context.MapRoute(
                "ChatLogically_default",
                "ChatLogically/{controller}/{action}/{id}",
                New With {.action = "SignalRChat", .id = UrlParameter.Optional}
            )
        End Sub
        'Public Overrides Sub RegisterArea(ByVal context As AreaRegistrationContext)
        '    context.MapRoute(
        '        "ChatLogically_default",
        '        "ChatLogically/{controller}/{action}/{id}",
        '        New With {.action = "Index", .id = UrlParameter.Optional}
        '    )
        'End Sub
    End Class
End Namespace