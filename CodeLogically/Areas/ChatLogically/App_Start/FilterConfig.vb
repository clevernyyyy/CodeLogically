﻿Imports System.Web
Imports System.Web.Mvc

Namespace ChatRoom
    Public Class FilterConfig
        Public Shared Sub RegisterGlobalFilters(filters As GlobalFilterCollection)
            filters.Add(New HandleErrorAttribute())
        End Sub
    End Class
End Namespace