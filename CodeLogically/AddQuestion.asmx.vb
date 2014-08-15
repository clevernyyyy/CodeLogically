Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.ComponentModel
Imports System.Net
Imports System.IO
Imports System.Web.Script.Serialization
Imports System.Collections.Specialized

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<System.Web.Services.WebService(Namespace:="http://tempuri.org/")> _
<System.Web.Services.WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<ToolboxItem(False)> _
<Script.Services.ScriptService()> _
Public Class AddQuestion
    Inherits System.Web.Services.WebService

    <WebMethod(True)> _
    Public Sub AddQuestion()
        Try
            Dim instance = New CreateNewSurvey

            instance.SaveCurrentList()
            instance.NewQuestion()
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

End Class